using Raylib_cs;
using System.Numerics;

namespace FogGateUI
{
    public class Rect
	{
		public Rectangle rec;
		public Color normal;
		public Color hovered;
		public Color clicked;

		public Rect(Rectangle rec, Color normal, Color hovered, Color clicked)
		{
			this.rec = rec;
			this.normal = normal;
			this.hovered = hovered;
			this.clicked = clicked;
		}

		public void draw(Vector2 mouse_pos)
		{
			if (Raylib.CheckCollisionPointRec(mouse_pos, rec))
			{
				if (Raylib.IsMouseButtonDown(MouseButton.Left))
				{
					Raylib.DrawRectangleRec(rec, clicked);
				}
				else
				{
					Raylib.DrawRectangleRec(rec, hovered);
				}
			}
			else
			{
				Raylib.DrawRectangleRec(rec, normal);
			}
		}
	}

	public class Text
	{
		public Vector2 position;
		public String text;
		public Color color;
		public int font_size;

		public Text(int posx, int posy, String text, int font_size, Color color)
		{
			position = new(posx, posy);
			this.text = text;
			this.font_size = font_size;
		}

		public void draw()
		{
            Raylib.DrawText(text, (int)position.X, (int)position.Y, font_size, Color.Black);
		}
	}

	public class Button: Rect
	{
		public Text text;
        private readonly Action? on_click;
		public bool task_running = false;
		public bool task_complete = false;
		public Button(Rectangle rec, Color normal, Color hovered, Color clicked,
			int window_width, int window_height,
			String text, int text_width, int text_height,
			Action? on_click = null
			)
            : base(rec, normal, hovered, clicked) 
		{
            int seed_width = text_width;
            int seed_height = text_height;
			int seed_pos_x = (int)rec.Position.X + (int)(rec.Width - text_width) / 2;
            int seed_pos_y = (int)rec.Position.Y + (int)(rec.Height - text_height)/2;
			this.text = new(seed_pos_x, seed_pos_y, text, text_height, Color.White);
			this.on_click = on_click;
		}

		public async Task click()
		{
			if (task_running) return;
			if (on_click == null) return;
			var task = Task.Run(() => {
				task_complete = false;
				task_running = true;
				on_click();
				task_complete = true;
				task_running = false;
			});
		}

		public async new void draw(Vector2 mouse_pos)
		{
			if (Raylib.CheckCollisionPointRec(mouse_pos, rec))
			{
				if (Raylib.IsMouseButtonDown(MouseButton.Left))
				{
					Raylib.DrawRectangleRec(rec, clicked);
				}
				else
				{
					Raylib.DrawRectangleRec(rec, hovered);
				}

				if (Raylib.IsMouseButtonReleased(MouseButton.Left))
				{
					await click();
				}
			}
			else
			{
				Raylib.DrawRectangleRec(rec, normal);
			}
			text.draw();
		}
	}

	public enum TextBoxState
	{
		Normal,
		Editing
	}

    public class TextBox : Rect
    {
		public Text text;
		public TextBoxState state = TextBoxState.Normal;
		int max_size;
		float held_time = 0.0f;
        public TextBox(Rectangle rec, Color normal, Color hovered, Color clicked, 
			int window_width, int window_height, 
			String text, int text_width, int text_height, int max_text_size)
            : base(rec, normal, hovered, clicked) 
		{
            int seed_width = text_width;
            int seed_height = text_height;
			int seed_pos_x = (int)rec.Position.X + text_height;
            int seed_pos_y = (int)rec.Position.Y + seed_height / 2;
			this.text = new(seed_pos_x, seed_pos_y, text, text_height, Color.White);
			max_size = max_text_size;
		}

		public String get()
		{
			return text.text;
		}

		void handle_input()
		{
			if (Raylib.IsKeyDown(KeyboardKey.Backspace) && text.text.Length > 0)
			{
                if (Raylib.IsKeyDown(KeyboardKey.LeftControl) || Raylib.IsKeyDown(KeyboardKey.RightControl))
                {
					text.text = "";
                }
				else
				{
                    if (held_time == 0.0f || held_time > 0.5f)
                    {
                        text.text = text.text.Substring(0, text.text.Length - 1);
                    }
                    held_time += Raylib.GetFrameTime();
				}
			}
			else
			{
				var key = Raylib.GetKeyPressed();
				if (key >= 48 && key <= 57 && text.text.Length < max_size)
				{
					text.text += (char)key;
				}
			}

			if (Raylib.IsKeyReleased(KeyboardKey.Backspace))
			{
				held_time = 0.0f;
			}

		}

		public new void draw(Vector2 mouse_pos)
		{

			if (state == TextBoxState.Editing)
			{
				handle_input();
			}
			var saved_text = this.text.text;
			if (state == TextBoxState.Editing) text.text += "_";
			if (Raylib.CheckCollisionPointRec(mouse_pos, rec))
			{
				if (Raylib.IsMouseButtonDown(MouseButton.Left))
				{
					Raylib.DrawRectangleRec(rec, clicked);
				}
				else
				{
					Raylib.DrawRectangleRec(rec, hovered);
				}
				
				if (Raylib.IsMouseButtonReleased(MouseButton.Left))
				{
					if (state != TextBoxState.Editing) state = TextBoxState.Editing;
				}
			}
			else
			{
				Raylib.DrawRectangleRec(rec, normal);

				if (Raylib.IsMouseButtonReleased(MouseButton.Left))
				{
					if (state != TextBoxState.Normal) state = TextBoxState.Normal;
				}
			}
			text.draw();
			text.text = saved_text;
		}

    }

	public class Information: Rect
	{
		public Text text;
		public bool show = false;
		float show_time = 0.0f;
		float max_show_time = 1.5f;
		int text_height;
		int window_width;
		int window_height;
		Color text_color;
		public Information(String text, int text_width, int text_height,
			int window_width, int window_height, Color bg_color, Color text_color)
			:base(
                 new Rectangle(
                     window_width - text_width - 3 * text_height,
                     window_height - text_height - 3 * text_height,
                     text_width + 2 * text_height,
                     text_height + 2 * text_height
                 ),
                 bg_color,
                 bg_color,
                 bg_color
            )
		{
			int padx = text_height;
			int pady = text_height;
			int posx = window_width - text_width - 2 * padx - padx;
			int posy = window_height - text_height - 2 * pady - pady;

			this.text = new Text(posx + padx, posy + pady, text, text_height, text_color);

			this.text_height = text_height;
			this.window_height = window_height;
			this.window_width = window_width;
			this.text_color = text_color;

		}

		public new void draw(Vector2 mouse_pos)
		{
			if (show)
			{
                base.draw(mouse_pos);
                text.draw();
				show_time += Raylib.GetFrameTime();
				if (show_time > max_show_time)
				{
					show = false;
					show_time = 0.0f;
				}
			}
		}

		public void display(String text)
		{
			int padx = text_height;
			int pady = text_height;
			int text_width = Raylib.MeasureText(text, text_height);
			int posx = window_width - text_width - 2 * padx - padx;
			int posy = window_height - text_height - 2 * pady - pady;

			rec = new Rectangle(
					 window_width - text_width - 3 * text_height,
					 window_height - text_height - 3 * text_height,
					 text_width + 2 * text_height,
					 text_height + 2 * text_height
				 );

			this.text = new Text(posx + padx, posy + pady, text, text_height, text_color);
			this.text.text = text;
			show = true;
		}
	}
}