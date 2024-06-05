import axios from "axios";

const rest = axios.create({
    baseURL: import.meta.env.VITE_API_URL,
  });

  export default {
    install: (app, options) => {
      const ConvertNumber = async (number) => {
            try {
              
              const res = await rest.post("/ConvertNumber",
              {
                Number : number      
              });
          
              return res.data;
          
            } catch (err) {
              throw new Error(err.response?.data?.detail 
                  ?? err.message);
            }
          };
          app.provide("ConvertNumber",ConvertNumber);
    },
  };