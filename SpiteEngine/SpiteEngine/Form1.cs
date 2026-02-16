using GameEngineAtt1;
using SpiteEngine.Libraries;
using System.Reflection;

namespace SpiteEngine
{
    public partial class Form1 : Form
    {
        public Scene pickedScene = new SampleScene();
        public List<Thing> currentSceneObjs = [];

        public Form1()
        {
            InitializeComponent();
            pickedScene.Setup();
            SetScene(pickedScene);

        }
        public void SetScene(Scene scn)
        {
            foreach (Thing obj in scn.stuff)
            {
                Thing ob_ = new(obj.name, obj.position, obj.scale, obj.rotation);
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
        private void UpdateLoop(object sender, EventArgs e)
        {
            foreach (Thing obj in currentSceneObjs)
                foreach (Script s in obj.components)
                    s.Update();

            foreach (InputButton b in Input.inputButtons)
                if (b.value == 3)
                    b.value = 0;
                else if (b.value == 1)
                    b.value = 2;
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
