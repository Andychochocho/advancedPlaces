using System.Collections.Generic;
namespace Places.Objects
{
  public class Place
  {
    private string _cityName;
    private int _dayStayed;
    private string _pictureLink;
    private static List<Place> _instances = new List<Place> {};
    public Place(string CityName, int DayStayed, string PictureLink)
    {
      _cityName = CityName;
      _dayStayed = DayStayed;
      _pictureLink = PictureLink;
      _instances.Add(this);
    }
    public string GetCities()
    {
      return _cityName;
    }
    public void SetCities(string newCityName)
    {
      newCityName = _cityName;
    }
    public int GetDays()
    {
      return _dayStayed;
    }
    public void SetDays(int newDays)
    {
      newDays = _dayStayed;
    }
    public string GetPicture()
    {
      return _pictureLink;
    }
    public void SetPicture(string newPicture)
    {
      newPicture = _pictureLink;
    }

    public static List<Place> GetAllPlaces()
    {
      return _instances;
    }
    public static void ClearAllPlaces()
    {
      _instances.Clear();
    }
  }
}
