// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
// import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyBjSi1OuBCbj1ukJAl8tOPHw0weZOnvq_k",
  authDomain: "trailtents.firebaseapp.com",
  projectId: "trailtents",
  storageBucket: "trailtents.appspot.com",
  messagingSenderId: "251115141567",
  appId: "1:251115141567:web:242aa3033e5d8abcad490a",
  measurementId: "G-R22NRD3T4Z"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
// const analytics = getAnalytics(app);

import {getstorage} from "firebase/storage";
const storage = getstorage(app);

export {storage};