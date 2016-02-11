using Nancy;
using Places.Objects;
using Categories.Objects;
using System.Collections.Generic;

namespace PlacesName
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] = _ => View["index.cshtml"];
      Get ["/categories"] = _ => {
        var allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };

      Get["/categories/new"] = _ => {
        return View["categoryForm.cshtml"];
      };

      Post["/categories"] = _ => {
        var newCategory = new Category(Request.Form["category-name"]);
        var allCategories = Category.GetAll();
        return View["categories.cshtml", allCategories];
      };

      Get["/categories/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedCategory = Category.Find(parameters.id);
        var categoryPlaces = selectedCategory.GetPlaces();
        model.Add("category", selectedCategory);
        model.Add("places", categoryPlaces);
        return View["category.cshtml", model];
      };

      Get["/categories/{id}/places/new"] = parameters => {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(parameters.id);
      List<Place> allPlaces = selectedCategory.GetPlaces();
      model.Add("category", selectedCategory);
      model.Add("places", allPlaces);
      return View["category_tasks_form.cshtml", model];

      };

      Post["/places"] = _ => {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Category selectedCategory = Category.Find(Request.Form["category-id"]);
      List<Place> categoryPlaces = selectedCategory.GetPlaces();
      Place newPlace = new Place(Request.Form["placeCity"], Request.Form["StayedDays"], Request.Form["AddPicture"]);
      categoryPlaces.Add(newPlace);
      model.Add("places", categoryPlaces);
      model.Add("category", selectedCategory);
      return View["category.cshtml", model];
    };


    Get ["/clearPlaces/{id}"] = parameters => {
      Category selectedCategory = Category.Find(parameters.id);
      selectedCategory.ClearAllPlaces();
      return View["clearPlaces.cshtml", selectedCategory];
    };

      //
      // Get["/viewPlaces"] = _ => {
      //   List<Place> allLists = Place.GetAllPlaces();
      //   return View["viewPlaces.cshtml", allLists];
      // };
      // Post["/viewPlaces"] = _ => {
      //   Place newPlace = new Place(Request.Form["placeCity"], Request.Form["StayedDays"], Request.Form["AddPicture"]);
      //   List<Place> allLists = Place.GetAllPlaces();
      //   return View["viewPlaces.cshtml", allLists];
      // };
      // Get["/viewPlaces/{id}"] = parameters => {
      //   Place place = Place.Find(parameters.id);
      //   return View["/place.cshtml", place];
      // };
    }
  }
}
