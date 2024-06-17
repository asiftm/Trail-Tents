<template>
  <div class="main">
    <div class="username-details" id="right-container">
      <p id="username-lbl">{{ fullname }}</p>
      <div class="right-details-container">
        <div class="details-container">
          <div class="details-lbl">
            <p>Firstname</p>
          </div>
          <div class="details-input-container"><input type="text" class="userinput" v-model="user.firstname"></div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Lastname</p>
          </div>
          <div class="details-input-container"><input type="text" class="userinput" v-model="user.lastname"></div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Date of Birth</p>
          </div>
          <div class="details-input-container"><input type="date" class="userinput" v-model="user.dateOfBirth"></div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Email</p>
          </div>
          <div class="details-input-container"><input type="text" class="userinput" v-model="user.email"></div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Address</p>
          </div>
          <div class="details-input-container"><input type="text" class="userinput" v-model="user.address"></div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Contact Number</p>
          </div>
          <div class="details-input-container"><input type="text" class="userinput" v-model="user.contactNumber">
          </div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Password</p>
          </div>
          <div class="details-input-container"><input type="password" class="userinput" v-model="user.password"></div>
        </div>
        <div class="details-container">
          <div class="details-lbl">
            <p>Confirm Password</p>
          </div>
          <div class="details-input-container"><input type="password" class="userinput" v-model="user.confirmPassword">
          </div>
        </div>
      </div>
      <div id="right-button-container">
        <ButtonWhite v-on:click="Reset()" text="Reset" />
        <ButtonWhite v-on:click="UpdateProfile()" text="Save" />
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
import ButtonWhite from "./ButtonWhite.vue"

export default {
  name: "UserProfileDetails",
  data() {
    return {
      user: {
        id: null,
        firstname: "",
        lastname: "",
        dateOfBirth: null,
        email: "",
        address: "",
        contactNumber: "",
        password: "",
        confirmPassword: "",
      },
      warningMessage: "",
      fullname: "",
    }
  },
  components: {
    ButtonWhite,
  },
  methods: {
    async UniqueEmail() {
      let decision = await axios.get(`https://localhost:5272/User/${this.email}/UniqueEmail`);
      console.log(decision.data)
      return decision.data;
    },
    async UpdateProfile() {
      if (this.CheckFields()) {
        if (this.user.password === this.user.confirmPassword) {
          if (confirm("Are you sure?")) {
            if (await this.UniqueEmail()) {
              this.UpdateUser();
            }
          }
        }
        else {
          confirm("Passwords are not same.\nPlease try again.");
        }
      }
      else {
        confirm("Please fill all fields.");
      }
    },
    async UpdateUser() {
      try {
        let result = await axios.put(`https://localhost:5272/User/${this.user.id}`, {
          firstname: this.user.firstname,
          lastname: this.user.lastname,
          dateOfBirth: this.user.dateOfBirth,
          email: this.user.email,
          address: this.user.address,
          contactNumber: this.user.contactNumber,
          password: this.user.password,
        });
        if (result.status == 200) {
          this.user.dateOfBirth = this.formatDate(this.user.dateOfBirth);
          localStorage.setItem("userInfo", JSON.stringify(this.user));
          this.Reset();
        }
      }
      catch {
        confirm("Email already in use")
      }
    }
    ,
    CheckFields() {
      for (const key in this.user) {
        if (this.user[key] === null) {
          return false;
        }
      }
      return true;
    },
    Reset() {
      let userInfo = localStorage.getItem("userInfo");
      if (!userInfo) {
        this.$router.push({ name: "UserLogin" });
      }
      else {
        const temp = JSON.parse(userInfo);
        this.user.id = temp.id;
        this.user.firstname = temp.firstname;
        this.user.lastname = temp.lastname;
        this.user.dateOfBirth = this.formatDate(temp.dateOfBirth);
        this.user.email = temp.email;
        this.user.address = temp.address;
        this.user.contactNumber = temp.contactNumber;
        this.user.password = temp.password;
        this.user.confirmPassword = "";
        this.fullname = this.user.firstname + " " + this.user.lastname
      }
    },
    formatDate(dateStr) {
      let formattedDate;
      if (dateStr.includes('/')) {
        // Input format: dd/mm/yyyy
        const [day, month, year] = dateStr.split('/');
        formattedDate = `${year}-${month.padStart(2, '0')}-${day.padStart(2, '0')}`;
      } else if (dateStr.includes('-')) {
        // Input format: yyyy-mm-dd
        const [year, month, day] = dateStr.split('-');
        formattedDate = `${day.padStart(2, '0')}/${month.padStart(2, '0')}/${year}`;
      } else {
        // Handle unsupported input format
        throw new Error('Unsupported date format');
      }
      return formattedDate;
    }
  },
  mounted() {
    this.Reset();
  }
}

</script>

<style scoped>
* {
  padding: 0;
  box-sizing: border-box;
  font-family: "Ysabeau Infant", sans-serif;
}

#right-container {
  width: 75%;
  font-size: 18px;
}

.right-details-container {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
}

#username-lbl {
  font-size: 44px;
  font-weight: 600;
  margin: 10px;
}

.username {
  display: grid;
  grid-template-columns: repeat(2, 1fr);
  justify-content: center;
  align-items: center;
  margin: 10px 15px;
}

.details-lbl {
  font-size: 24px;
}

.details-container{
  padding: 10px;
}

.details-input-container input {
  width: 100%;
  height: 45px;
  border-radius: 5px;
  border: 2px solid;
  border-radius: 10px;
  padding: 2px;
  font-size: 20px;
  font-weight: 600;
}

#right-button-container {
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
}
</style>
