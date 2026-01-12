using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tofu13
{
    class IngredientStock
    {
        public int Water = 1000;
        public int Coffee = 100;
        public int Milk = 50;
        public int Chocolate = 50;

        public bool HasEnough(Dictionary<string, int> need)
        {
            foreach (var item in need)
            {
                if (GetAmount(item.Key) < item.Value)
                    return false;
            }
            return true;
        }

        public void Use(Dictionary<string, int> need)
        {
            foreach (var item in need)
            {
                SetAmount(item.Key, GetAmount(item.Key) - item.Value);
            }
        }

        public void Refill()
        {
            Water += 1000;
            Coffee += 100;
            Milk += 50;
            Chocolate += 50;
            Console.WriteLine("ระบบเติมวัตถุดิบเรียบร้อย");
        }

        private int GetAmount(string name)
        {
            if (name == "Water") return Water;
            if (name == "Coffee") return Coffee;
            if (name == "Milk") return Milk;
            if (name == "Chocolate") return Chocolate;
            return 0;
        }

        private void SetAmount(string name, int value)
        {
            if (name == "Water") Water = value;
            else if (name == "Coffee") Coffee = value;
            else if (name == "Milk") Milk = value;
            else if (name == "Chocolate") Chocolate = value;
        }
    }

    class Drink
    {
        public string Name;
        public Dictionary<string, int> Ingredients;

        public Drink(string name, Dictionary<string, int> ingredients)
        {
            Name = name;
            Ingredients = ingredients;
        }
    }

    class CoffeeMachine
    {
        IngredientStock stock = new IngredientStock();

        public void MakeDrink(Drink drink)
        {
            if (!stock.HasEnough(drink.Ingredients))
            {
                Console.WriteLine("วัตถุดิบไม่พอ กำลังเติม...");
                stock.Refill();
            }

            stock.Use(drink.Ingredients);
            Console.WriteLine("กำลังชง " + drink.Name);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
    Console.OutputEncoding = System.Text.Encoding.UTF8;
    Console.InputEncoding = System.Text.Encoding.UTF8;

            CoffeeMachine machine = new CoffeeMachine();

            Dictionary<int, Drink> drinks = new Dictionary<int, Drink>();
            drinks.Add(1, new Drink("กาแฟดำ",
                new Dictionary<string, int> { { "Water", 300 }, { "Coffee", 20 } }));
            drinks.Add(2, new Drink("มอคค่า",
                new Dictionary<string, int> { { "Water", 300 }, { "Coffee", 20 }, { "Chocolate", 10 } }));
            drinks.Add(3, new Drink("ลาเต้",
                new Dictionary<string, int> { { "Water", 300 }, { "Coffee", 20 }, { "Milk", 10 } }));
            drinks.Add(4, new Drink("ช๊อคโกเล็ต",
                new Dictionary<string, int> { { "Water", 300 }, { "Chocolate", 20 } }));

            while (true)
            {
                Console.WriteLine("\n--- เมนูเครื่องดื่ม ---");
                Console.WriteLine("1. กาแฟดำ");
                Console.WriteLine("2. มอคค่า");
                Console.WriteLine("3. ลาเต้");
                Console.WriteLine("4. ช๊อคโกเล็ต");
                Console.WriteLine("0. ออกจากโปรแกรม");
                Console.Write("เลือกเมนู: ");

                string input = Console.ReadLine();

                if (input == "0")
                    break;

                if (input == "1" || input == "กาแฟดำ")
                    machine.MakeDrink(drinks[1]);
                else if (input == "2" || input == "มอคค่า")
                    machine.MakeDrink(drinks[2]);
                else if (input == "3" || input == "ลาเต้")
                    machine.MakeDrink(drinks[3]);
                else if (input == "4" || input == "ช๊อคโกเล็ต")
                    machine.MakeDrink(drinks[4]);
                else
                    Console.WriteLine("เลือกเมนูไม่ถูกต้อง");
            }
        }
    }
}