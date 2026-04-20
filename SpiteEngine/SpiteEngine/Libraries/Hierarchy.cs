using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteEngine.Libraries
{
    public class Thing(string _someCoolName, Point _position, Size _scale, params Script[] _components)
    {
        public string name = _someCoolName;
        public Point position = _position;
        public Size scale = _scale;
        public List<Script> components { get; set; } = [.. _components.OfType<Script>()];

        public Script? GetComponent<C>() where C : Script
        {
            return components.OfType<C>().FirstOrDefault();
        }
    }
    public abstract class Script 
    {
        public Thing object_;
        public Form1 game;

        public virtual void Start()
        {
            
        }
        public virtual void Update()
        {

        }
        public virtual void OnDestroy()
        {
        }
    }
    public abstract class Scene
    {
        public List<Thing> stuff = [];
        public Color windowColor = Color.White;
        public Size windowSize = new(600, 600);

        public virtual void Setup()
        {

        }
        protected internal void Add(Thing object_, params Script[] scripts)
        {
            Thing o = object_;
            for (int i = 0; i < scripts.Length; i++)
                o.components.Add(scripts[i]);
            stuff.Add(o);
            System.Diagnostics.Debug.WriteLine(o.components.Count);
        }
    }
}
