using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace SkateparkManagement
{
    public static class Database
    {
        private static string userFilePath = "users.json";
        private static string articleFilePath = "articles.json";

        public static List<User> Users { get; set; } = new List<User>();
        public static List<Article> Articles { get; set; } = new List<Article>();

        static Database()
        {
            LoadUsers();
            LoadArticles();
        }

        public static void LoadUsers()
        {
            if (File.Exists(userFilePath))
            {
                var jsonData = File.ReadAllText(userFilePath);
                Users = JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
        }

        public static void LoadArticles()
        {
            if (File.Exists(articleFilePath))
            {
                var jsonData = File.ReadAllText(articleFilePath);
                Articles = JsonConvert.DeserializeObject<List<Article>>(jsonData);
            }
        }

        public static void Save()
        {
            var userJsonData = JsonConvert.SerializeObject(Users, Formatting.Indented);
            File.WriteAllText(userFilePath, userJsonData);

            var articleJsonData = JsonConvert.SerializeObject(Articles, Formatting.Indented);
            File.WriteAllText(articleFilePath, articleJsonData);
        }
    }
}
