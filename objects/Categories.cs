using System.Collections.Generic;
using Places.Objects;

namespace Categories.Objects
{
  public class Category
  {
    private static List<Category> _instances = new List<Category> {};
    private string _name;
    private int _id;
    private List<Place> _places;

    //creates list to contain all categories + variables//

    public Category(string categoryName)
    {
      _name = categoryName;
      _instances.Add(this);
      _id = _instances.Count;
      _places = new List<Place>{};
    }

  //constructor for category.//

    public string GetName()
    {
      return _name;
    }

    //don't need set because we don't need the user to "write" over the variable once its been created//

    public int GetId()
    {
      return _id;
    }

    //returns list of all places associated with that category//
    public List<Place> GetPlaces()
    {
      return _places;
    }

//adds task to category list//

    public void AddPlace(Place place)
    {
      _places.Add(place);
    }

  //gets all of the categories//
    public static List<Category> GetAll()
    {
      return _instances;
    }
    public static void ClearCategories()
    {
      _instances.Clear();
    }

    public void ClearAllPlaces()
    {
      _places.Clear();
    }

    public static Category Find(int searchId)
    {
      return _instances[searchId-1];
    }
  }
}
