using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodsharing.Models;


// В данном файле создается коллекция и обозначаются команды

namespace foodsharing.Services
{
	public class PostService : IDataStore<Post>
    {
        readonly List<Post> posts;

        public PostService()
		{
            // Здесь мы создаем коллекцию элементов с параметрами указанными в модели "Post"
            posts = new List<Post>()
            {
				new Post(){Id = Guid.NewGuid().ToString(), PostName= "Мешок картошки", Adress="Москва, Коштоянца 5", ImageUrl= "potato.jpeg",
                    Description="Отдам мешок картошки с огорода, приходите!", UserName="Антон", PhoneNumder="+7 (926) 132 56 56" },
                new Post(){Id = Guid.NewGuid().ToString(), PostName= "Лазанья", Adress="Москва, Лобачевского 23", ImageUrl= "lasagna.jpeg",
                    Description="Приготовила обалденную лазанью, поделюсь с нуждающимися. Жду в гости!", PhoneNumder="+7 (989) 678 34 54", UserName="Анжела" },
                new Post(){Id = Guid.NewGuid().ToString(), PostName= "Выпечка бесплатно", Adress="Москва, Кузнецкий мост 12/3", ImageUrl= "bakery.jpeg",
                    Description="Пекарня 'French Bakery' на Кузнецком мосту ежедневно проводит раздачу нераспроданной выпечки по вечерам с 22.00 по 23.00. Ждем всех нуждающихся в нашей пекарне!",
                    UserName="Александр", PhoneNumder="+7 (495) 567 43 12"},
                new Post(){Id = Guid.NewGuid().ToString(), PostName= "Овощи", Adress="Москва, Шухова 2", ImageUrl= "vegetables.jpeg",
                    Description="Урожай в этом году выдался добротным! С мужем сами все не съедим, поделимся с нуждающимися, звоните.",
                    PhoneNumder="+7 (929) 655 45 89", UserName="Людмила"},
                new Post(){Id = Guid.NewGuid().ToString(), PostName= "Сендвич с тунцом", Adress="Москва, Удальцова 73", ImageUrl= "sandwich.jpeg",
                    Description="Приходите на чай с сэндвичами! Скучно одному сидеть дома(", PhoneNumder="+7 (981) 879 20 11", UserName="Олег" },
                new Post(){Id = Guid.NewGuid().ToString(), PostName= "Домашний борщ", Adress="Москва, Пр-т Ленина 40", ImageUrl= "borsch.jpeg",
                    Description="Одинокая женщина 40 лет, приглашает мужчину на вкусный наваристый борщ))", UserName="Изольда", PhoneNumder="+7 (926) 666 31 45"},
            };
		}


        // Создается команда добавления элемента в коллекцию, в нашем случае - объявления
        public async Task<bool> AddPostAsync(Post post)
        {
            posts.Add(post);
            return await Task.FromResult(true);
        }

        // Создается команда вызова конкретного объявления
        public async Task<Post> GetPostAsync(string id)
        {
            return await Task.FromResult(posts.Last(s => s.Id == id));
        }

        // Создается команда вызова коллекции объявлений
        public async Task<IEnumerable<Post>> GetPostsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(posts);
        }
        
    }
}

