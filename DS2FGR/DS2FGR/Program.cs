using FogWallNS;
using Raylib_cs;
using FogGateUI;

Randomizer randomizer = new();

int window_width = 800;
int window_height = 600;

int text_height = 20;

int? randomized_seed = null;

Random rand = new Random();
int max_random_num = 999_999_999;
String max_random_num_str = max_random_num.ToString();

int max_random_num_width = Raylib.MeasureText(max_random_num_str, text_height);

String previous_seed_path = "seed.txt";

int seed = rand.Next(1, max_random_num);
String seed_str = seed.ToString();
if (File.Exists(previous_seed_path))
{
    seed_str = File.ReadAllText(previous_seed_path);
    if (int.TryParse(seed_str, out int value))
    {
        seed = value;
    }
    else
    {
        seed = rand.Next(1, max_random_num);
    }
}

Raylib.InitWindow(window_width, window_height, "DS2 Fog Gate Randomizer");
Raylib.SetTargetFPS(15);

var icon = Raylib.LoadImage("./res/icon.png");
Raylib.SetWindowIcon(icon);

String info_text = "This is information";
Information info = new(info_text, Raylib.MeasureText(info_text, text_height), text_height,
    window_width, window_height, Color.Beige, Color.White);

App app = new(text_height, window_width, window_height);
CheckButton item_rando_check_button = new("Load Item Rando", 0, 0, Color.White, text_height);


int button_width = window_width / 5;
int button_height = window_height / 10;
int button_pos_x = (window_width - button_width) / 2;
int button_pos_y = (window_height - button_height) / 2;
Rectangle button_rect = new(button_pos_x, button_pos_y, button_width, button_height);

int pady = text_height;

int text_box_width = window_width / 5;
int text_box_height = text_height * 2;
int text_box_pos_x = (window_width - text_box_width) / 2;
int text_box_pos_y = button_pos_y - text_box_height - pady;
Rectangle text_box_rect = new(text_box_pos_x, text_box_pos_y, text_box_width, text_box_height);

Color text_box_normal_color = new Color(200, 200, 200);
Color text_box_hover_color = Color.Gray;
Color text_box_active_color = Color.White;


String button_text = "Randomize";
var text_width = Raylib.MeasureText(button_text, text_height);

int text_pos_x = (window_width - text_width) / 2;
int text_pos_y = (window_height - text_height) / 2;

TextBox text_box = new TextBox(text_box_rect, text_box_normal_color, text_box_hover_color, text_box_active_color,
    window_width, window_height, seed_str, max_random_num_width, text_height, max_random_num_str.Length);

Button randomize_button = new(button_rect,
    Color.Red, Color.Green, Color.Blue,
    window_width, window_height, 
    button_text, Raylib.MeasureText(button_text, text_height), text_height,
    on_click: async () => {
        seed_str = text_box.text.text;
        if (int.TryParse(seed_str, out int result))
        {
            seed = result;
        }
        else
        {
            info.display("Invalid seed");
            return false;
        }
        randomizer.load_item_rando = item_rando_check_button.state;
        if (item_rando_check_button.state)
        {
            if (!Path.Exists("../randomizer/DS2SRandomizer.exe")) 
            {
                info.display($"Item Rando not installed. Uncheck the top option to proceed.");
                return false;
            }
        }
        info.display($"Randomization with seed: {seed}");
        await randomizer.randomize(seed);
        randomized_seed = seed;
        return true;
    });



int random_seed_button_width  = window_width / 10;
int random_seed_button_height = text_box_height;
int padx = text_height;
int random_seed_button_posx = text_box_pos_x - random_seed_button_width - padx;
int random_seed_button_posy = text_box_pos_y;
Rectangle random_seed_button_rec = new(random_seed_button_posx, random_seed_button_posy, random_seed_button_width, random_seed_button_height);
//Rect random_seed_button = new(random_seed_button_rec, Color.Blue, Color.Green, Color.Red);
String random_seed_button_text = "New";
Button random_seed_button = new(random_seed_button_rec,
    Color.Red, Color.Green, Color.Blue,
    window_width, window_height, random_seed_button_text,
    Raylib.MeasureText(random_seed_button_text, text_height), text_height,
    on_click: async () =>
    {
        seed = rand.Next(1, max_random_num);
        seed_str = seed.ToString();
        text_box.text.text = seed_str;
        return true;
    }
);

float time_accum = 0.0f;
void randomizer_running_state(String randomizing_text, int posx, int posy, int text_height, Color color)
{
        if (time_accum < 0.25f)
        {
            Raylib.DrawText(randomizing_text, posx, posy, text_height, color);
        }
        else if (time_accum < 0.5f)
        {
            Raylib.DrawText(randomizing_text+".", posx, posy, text_height, color);
        }
        else if (time_accum < 1.0f)
        {
            Raylib.DrawText(randomizing_text+"..", posx, posy, text_height, color);
        }
        else if (time_accum < 1.5f)
        {
            Raylib.DrawText(randomizing_text, posx, posy, text_height, color);
            time_accum = 0.0f;
        }
        time_accum += Raylib.GetFrameTime();

}

int copy_btn_width = 75;
int copy_btn_height = text_box_height;

Rectangle copy_button_rec = new(
    text_box_pos_x + text_box_width + padx,
    text_box_pos_y,
    copy_btn_width,
    copy_btn_height
);

String copy_btn_txt = "Copy";
Button copy_button = new(copy_button_rec,
    Color.Beige, Color.Green, Color.Blue,
    window_width, window_height, copy_btn_txt,
    Raylib.MeasureText(copy_btn_txt, text_height), text_height,
    async () => {
        Raylib.SetClipboardText(text_box.get());
        info.display($"Copied `{text_box.get()}` to clipboard");
        return true;
    }
);

int paste_btn_width = 75;
int paste_btn_height = text_box_height;

Rectangle paste_button_rec = new(
    copy_button_rec.Position.X + copy_button_rec.Size.X + padx/2,
    text_box_pos_y,
    paste_btn_width,
    paste_btn_height
);

String paste_btn_txt = "Paste";
Button paste_button = new(paste_button_rec,
    Color.Beige, Color.Green, Color.Blue,
    window_width, window_height, paste_btn_txt,
    Raylib.MeasureText(paste_btn_txt, text_height), text_height,
    async () => {
        String text = Raylib.GetClipboardText_();
        if (int.TryParse(text, out int result))
        {
            seed = result;
            text_box.text.text = seed.ToString();
            info.display($"Set seed to `{seed}`");
            return true;
        }
        else
        {
            info.display($"Invalid seed `{text}`");
            return false;
        }
    }
);


Color bg_color = new(20, 20, 20);
String randomizing_text = "Randomizing.";
int randomizing_text_width = Raylib.MeasureText(randomizing_text, text_height);
int posx = (window_width - randomizing_text_width) / 2;
int posy = (window_height - text_height) / 2;

while (!Raylib.WindowShouldClose())
{
    var mouse_pos = Raylib.GetMousePosition();
    Raylib.ClearBackground(bg_color);
    Raylib.BeginDrawing();
    if (randomize_button.task_running)
    {
        randomizer_running_state(randomizing_text, posx, posy, text_height, Color.White);
    } else
    {
        if (randomize_button.task_complete)
        {
            info.display("Randomization Complete");
            randomize_button.task_complete = false;
        }
        text_box.draw(mouse_pos);
        copy_button.draw(mouse_pos);
        paste_button.draw(mouse_pos);

        randomize_button.draw(mouse_pos);
        random_seed_button.draw(mouse_pos);
        item_rando_check_button.draw(app, mouse_pos);

        info.draw(mouse_pos);

    }
    Raylib.EndDrawing();
}

if (randomized_seed != null)
{
    File.WriteAllText(previous_seed_path, randomized_seed.ToString());
}

Raylib.CloseWindow();
