namespace _04._Wild_Farm.Models.Food;

public abstract class Food
{
    public int FoodQuantity;

    protected Food(int foodQuantity) => FoodQuantity = foodQuantity;
}