using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace SDM_Compulsory_Assignment
{
    public class repo
    {
        public string JsonUrl;
        public IEnumerable<Review> MovieReviews { get; set; }

        public repo (string jsonUrl)
        {
            JsonUrl = jsonUrl;
        }

        public void fillRepo()
        {
            using (StreamReader file = File.OpenText(JsonUrl))
            {
                MovieReviews = JsonConvert.DeserializeObject<IEnumerable<Review>>(file.ReadToEnd());
            }
        }

        public IEnumerable<Review> GetMovieReviews()
        {
            if (MovieReviews == null)
            {
                fillRepo();
            }
            return MovieReviews;
        }


    }
}
