using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiteEngine.Libraries
{
    public class Thing(string _someCoolName, Point _position, Size _scale, int _rotation, params Script[] _components)
    {
        public string name = _someCoolName;
        public Point position = _position;
        public Size scale = _scale;
        public int rotation = _rotation;
        public List<Script> components { get; set; } = [.. _components.OfType<Script>()];
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
        public void Destroy(Thing thingy)
        {
            foreach (Script s in thingy.components)
                Destroy(s);
            game.currentSceneObjs.Remove(thingy);
        }
        public void Destroy(Script script)
        {
            script.OnDestroy();
            game.currentSceneObjs.Find(t => t.name == script.object_.name).components.Remove(script);
        }
    }
    public abstract class Scene
    {
        public List<Thing> stuff = [];

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
