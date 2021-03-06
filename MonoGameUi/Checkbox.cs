﻿using engenious;
using engenious.Graphics;


namespace MonoGameUi
{
    public class Checkbox : ContentControl
    {
        public Brush BoxBrush { get; set; }

        public Brush InnerBoxBrush { get; set; }

        public Brush HookBrush { get; set; }

        private bool boxChecked = false;

        public bool Checked
        {
            get
            {
                return boxChecked;
            }

            set
            {
                boxChecked = value;
                if (CheckedChanged != null)
                    CheckedChanged.Invoke(boxChecked);
            }
        }

        public event CheckedChangedDelegate CheckedChanged;


        public Checkbox(IScreenManager manager)
            : base(manager)
        {
            CanFocus = true;
            TabStop = true;
            ApplySkin(typeof(Checkbox));
        }

        protected override void OnDrawContent(SpriteBatch batch, Rectangle contentArea, GameTime gameTime, float alpha)
        {
            int innerDistanceX = contentArea.Width / 18;
            int innerDistanceY = contentArea.Height / 18;

            int hookDistanceX = contentArea.Height / 7;
            int hookDistanceY = contentArea.Width / 7;

            BoxBrush.Draw(batch, contentArea, alpha);
            InnerBoxBrush.Draw(batch, new Rectangle(contentArea.X + innerDistanceX, contentArea.Y + innerDistanceY,
                    contentArea.Width - innerDistanceX * 2, contentArea.Height - innerDistanceY * 2), alpha);
            if (Checked)
                HookBrush.Draw(batch, new Rectangle(contentArea.X + hookDistanceX, contentArea.Y + +hookDistanceY,
                        contentArea.Width - hookDistanceX * 2, contentArea.Height - hookDistanceY * 2), alpha);
        }

        protected override void OnLeftMouseClick(MouseEventArgs args)
        {
            Checked = !Checked;
        }

        protected override void OnKeyDown(KeyEventArgs args)
        {
            if (Focused == TreeState.Active && args.Key == engenious.Input.Keys.Enter)
                Checked = !Checked;
        }

        public delegate void CheckedChangedDelegate(bool Checked);
    }
}
