namespace Framework.Models
{
    public class Card
    {
        //virtual gives the object new functionality
        public virtual string ID {get; set; }
        public virtual string Name {get; set;}
        public virtual string Icon {get; set;}
        public virtual int Cost {get; set;}
        public virtual string Type {get; set;}
        public virtual string Arena {get; set;}
    }
}