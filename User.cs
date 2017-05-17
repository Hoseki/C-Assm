using System;

public class User
{
    private int id;
    private string name;
    private string phone;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    public string Phone
    {
        get { return phone; }
        set { phone = value; }
    }

    public User(int id, string name, string phone)
    {
        this.id = id;
        this.name = name;
        this.phone = phone;

    }

    public User()
    {
    }

}
