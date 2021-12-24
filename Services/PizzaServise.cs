using ContosoPizza.Models;

namespace ContosoPizza.Services
{
    public class PizzaServise
    {
        static List<Pizza> Pizzas { get; }
        static int NextId = 3;
        static PizzaServise()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza {Id=1,Name="Italian",IsGlutenFree=false},
                new Pizza {Id=2,Name="Veggie",IsGlutenFree=true}
            };
        }

        public static List<Pizza> GetAll() => Pizzas;
        public static Pizza? GetById(int id) => Pizzas.FirstOrDefault(p => p.Id == id);
        public static void Add(Pizza pizza)
        {
            NextId++;
            Pizzas.Add(pizza);
        }

        public static void Delete(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;
            else
                Pizzas.Remove(pizza);
        }

        public static void Update(Pizza pizza)
        {
            var index = Pizzas.FindIndex(p => p.Id == pizza.Id);
            if (index == -1)
                return;
            else
                Pizzas[index] = pizza;
        }

    }
}