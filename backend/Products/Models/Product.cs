namespace Products.Models;

public class Product {
    public int? Id { get; set; }
    public string Category { get; set; }
    public string Name { get; set; }
    public float Price { get; set; }
    public string Description { get; set; }
    public string PicUrl { get; set; }

    public Product(string category, string name, float price, string description, string picUrl) {
        this.Category = category;
        this.Name = name;
        this.Price = price;
        this.Description = description;
        this.PicUrl = picUrl;
    }

    public Product() {
        this.Category = "";
        this.Name = "";
        this.Price = 0;
        this.Description = "";
        this.PicUrl = "";
    }
}
