<template>
  <div class="main">
    <p>
      My Reviews
    </p>
    <div class="review-container">
      <div class="review" v-for="(item, index) in reviewList" :key="index">
        <div class="review-item" id="campsiteName">
          <button>{{ item.campsiteName }}</button>
        </div>
        <div class="review-item" id="comment">
          {{ item.comment }}
        </div>
        <div class="review-item" id="rating">
          <div class="rating-star-container" v-for="(i, index) in item.rating" :key="index">
            <img src="../assets/1149472-removebg-preview.png" alt="">
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// import axios from "axios";

export default {
  name: "UserReview",
  data() {
    return {
      user_id: null,
      reviewList: []
    }
  },
  methods: {
    // async GetUserReviews() {
    //   try {
    //     let result = await axios.get(`https://localhost:5272/User/${this.user_id}/Reviews`);
    //     if (result.status == 200 && result.data != null) {
    //       for (let i = 0; i < result.data.length; i++) {
    //         let campsitedata = await this.GetCampsite(result.data[i].campsiteID)
    //         let dataDict = {
    //           comment: result.data[i].comment,
    //           rating: result.data[i].rating,
    //           campsiteID: result.data[i].campsiteID,
    //           campsiteName: campsitedata.name
    //         }
    //         this.reviewList.push(dataDict);
    //         console.log(typeof(dataDict.rating))
    //       }
    //     }
    //   } catch (error) {
    //     console.log(error)
    //   }
    // },
    // async GetCampsite(id) {
    //   try {
    //     let result = await axios.get(`https://localhost:5272/CampingSite/${id}`);
    //     if (result.status == 200 && result.data != null) {
    //       return result.data
    //     }
    //   } catch (error) {
    //     console.log(error)
    //   }
    // },
  },
  mounted() {
    let userInfo = localStorage.getItem("userInfo");
    if (!userInfo) {
      this.$router.push({ name: "UserLogin" });
    } else {
      const user = JSON.parse(userInfo);
      this.user_id = user.id;
      // this.GetUserReviews(this.user_id);
      let dataDict = {
        comment: "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
        rating: 5,
        campsiteID: 1,
        campsiteName: "Natures queen"
      }
      this.reviewList.push(dataDict);
      dataDict = {
        comment: "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like). Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
        rating: 3,
        campsiteID: 1,
        campsiteName: "Natures queen"
      }
      this.reviewList.push(dataDict);
    }
  },
}
</script>

<style>
.main {
  font-family: "Ysabeau Infant", sans-serif;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.main p {
  font-size: 28px;
  font-weight: 600;
}

.main button{
  background: none;
  padding-bottom: 5px;
  box-shadow: none;
}

.review-container {

}

.review {
  height: auto;
  width: 600px;
  border-radius: 4px;
  margin-bottom: 30px;
  box-shadow: 0 5px 10px rgba(0, 0, 0, 0.3);
  background-color: #f0f0f0;
  position: relative;
}

.review-item {
  padding: 5px;
}


#rating {
  padding: 0;
  display: flex;
  flex-direction: row;
  position: absolute;
  top: -15px;
  right: 0;
}

.rating-star-container {
  display: flex;
}

.rating-star-container img {
  object-fit: cover;
  height: 30px;
  width: 30px;
  padding: 0px 5px;
}

#campsiteName {
  font-size: 20px;
  font-weight: 600;
}
</style>