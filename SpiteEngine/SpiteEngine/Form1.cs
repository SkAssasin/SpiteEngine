using SpiteEngine;
using SpiteEngine.Libraries;
using System.Reflection;
using System.Diagnostics;
using System;
using SpiteEngine.Properties;

namespace SpiteEngine
{
    public partial class Form1 : Form
    {
        public Scene pickedScene = new SampleScene();
        public List<Thing> currentSceneObjs = [];
        public Scene newScene;

        public Form1()
        {
            InitializeComponent();
            pickedScene.Setup();
            SetScene(pickedScene);
        }
        public void ChangeScene(Scene scn) { newScene = scn; }
        void SwapScene(Scene scn)
        {
            for (int i = currentSceneObjs.Count - 1; i >= 0; i--)
                Destroy(currentSceneObjs[i]);
            currentSceneObjs.RemoveAll(t => t != null);
            scn.Setup();
            SetScene(scn);
        }
        public void SetScene(Scene scn)
        {
            pickedScene = newScene;
            foreach (Thing obj in scn.stuff)
            {
                Thing ob_ = new(obj.name, obj.position, obj.scale);
                foreach (Script s in obj.components)
                {
                    var sc = s.GetType();
                    foreach (PropertyInfo variable in s.GetType().GetProperties())
                        variable.SetValue(obj, sc, null);
                    ob_.components.Add(s);
                    s.object_ = obj;
                    s.game = this;
                    s.Start();
                }
                currentSceneObjs.Add(ob_);
            }
        }
        public void SaveScene(string name)
        {
            string? n = name == "" ? pickedScene.GetType().ToString() : name;

            using(StreamWriter sw = File.CreateText("C:\\Users\\simon\\Documents\\VS Projects\\VS\\SpiteEngine\\SpiteEngine\\SpiteEngine\\" + name + ".cs"))
            {
                sw.WriteLine("using SpiteEngine.Libraries;\r\nusing SpiteEngine.Properties;\r\n\r\n\r\nnamespace SpiteEngine\r\n{\r\n\tinternal class " + name + " : Scene\r\n\t{\r\n\t\tpublic override void Setup()\r\n\t\t{");
                foreach (Thing t in currentSceneObjs)
                {
                    sw.Write("\t\t\tAdd(new(\"{0}\", new({1}, {2}), new({3}, {4})", t.name, t.position.X, t.position.Y, t.scale.Width, t.scale.Height);
                    foreach (Script s in t.components)
                    {
                        var sc = s.GetType();
                        sw.Write(", new {0}(", s);
                        foreach (ConstructorInfo v in sc.GetConstructors())
                        {
                            int count = v.GetParameters().Length;
                            foreach (ParameterInfo p in v.GetParameters())
                            {
                                if (p.ParameterType == typeof(int))
                                    sw.Write("999");
                                else if (p.ParameterType == typeof(string))
                                    sw.Write("\"text ig?\"");
                                else if (p.ParameterType == typeof(bool))
                                    sw.Write("true");
                                else if (p.ParameterType == typeof(Image))
                                    sw.Write("Resources.Player");
                                else
                                    sw.Write("Null");

                                if (count > 1) sw.Write(", ");
                                count--;
                            }
                        }
                        sw.Write(")");
                    }
                    sw.Write("));\r\n");
                }
                sw.WriteLine("\t\t}\r\n\t}\r\n}");
            }
        }
        private void UpdateLoop(object sender, EventArgs e)
        {
            currentSceneObjs.ForEach(t => t.components.ForEach(c => c.Update()));
            if (newScene != pickedScene) SwapScene(newScene);
            foreach (InputButton b in Input.inputButtons)
                if (b.value == 3)
                    b.value = 0;
                else if (b.value == 1)
                    b.value = 2;
        }
        public void Destroy(Thing thingy)
        {
            for (int i = thingy.components.Count - 1; i >= 0; i--)
                Destroy(thingy.components[i]);
        }
        public void Destroy(Script script)
        {
            script.OnDestroy();
            try
            {
                currentSceneObjs.Find(t => t.name == script.object_.name).components.Remove(script);
            }
            catch { }
        }

        private void KeyReleased(object sender, KeyEventArgs e)
        {
            foreach (InputAxis i in Input.inputAxis)
                if (i.positiveKey.Contains(e.KeyCode) || i.negativeKey.Contains(e.KeyCode))
                    i.value = 0;
            foreach (InputButton b in Input.inputButtons)
                if (b.key.Contains(e.KeyCode))
                    b.value = 3;
        }
        private void KeyPressed(object sender, KeyEventArgs e) // toto je drzanie tlacidla, nie stlacenie
        {
            foreach (InputAxis i in Input.inputAxis) // 2D
                if (i.positiveKey.Contains(e.KeyCode))
                    if (i.value == -1)
                        i.value = 0;
                    else
                        i.value = 1;
                else if (i.negativeKey.Contains(e.KeyCode))
                    if (i.value == 1)
                        i.value = 0;
                    else
                        i.value = -1;
            foreach (InputButton b in Input.inputButtons) // 1D
                if (b.key.Contains(e.KeyCode))
                    if (b.value == 0 || b.value == 3)
                        b.value = 1;
        }
    }
}
