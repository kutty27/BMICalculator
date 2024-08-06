using Android.App;
using Android.OS;
using Android.Widget;

namespace BMICalculatorApp
{
    [Activity(Label = "BMICalculatorApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private EditText? _weightInput;
        private EditText? _heightInput;
        private Button? _calculateButton;
        private TextView? _bmiResult;

        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            // Initialize UI elements using direct resource IDs
            _weightInput = FindViewById<EditText>(Resource.Id.weightInput);
            _heightInput = FindViewById<EditText>(Resource.Id.heightInput);
            _calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            _bmiResult = FindViewById<TextView>(Resource.Id.bmiResult);

            // Set up event handler for the button
            if (_calculateButton != null)
            {
                _calculateButton.Click += (sender, e) => CalculateBMI();
            }
        }

        //protected override void OnCreate(Bundle? savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);
        //    SetContentView(Resource.Layout.activity_main);

        //    // Initialize UI elements using resource IDs
        //    _weightInput = FindViewById<EditText>(GetIdentifier("weightInput", "id"));
        //    //  _weightInput = FindViewById<EditText>(Resource.Id.weightInput);
        //    _heightInput = FindViewById<EditText>(GetIdentifier("heightInput", "id"));
        //    _calculateButton = FindViewById<Button>(GetIdentifier("calculateButton", "id"));
        //    _bmiResult = FindViewById<TextView>(GetIdentifier("bmiResult", "id"));

        //    // Set up event handler for the button
        //    if (_calculateButton != null)
        //    {
        //        _calculateButton.Click += (sender, e) => CalculateBMI();
        //    }
        //}

        //private int GetIdentifier(string name, string type)
        //{
        //    if (Resources == null || string.IsNullOrEmpty(PackageName))
        //    {
        //        return -1;
        //    }

        //    return Resources.GetIdentifier(name, type, PackageName);
        //}

        private void CalculateBMI()
        {
            if (_weightInput != null && _heightInput != null && _bmiResult != null)
            {
                // Get weight and height from user inputs
                string? weightText = _weightInput.Text;
                string? heightText = _heightInput.Text;

                // Parse weight and height
                if (float.TryParse(weightText, out float weight) && float.TryParse(heightText, out float height))
                {
                    // Convert height from centimeters to meters
                    float heightInMeters = height / 100;

                    // Calculate BMI
                    if (heightInMeters > 0)
                    {
                        float bmi = weight / (heightInMeters * heightInMeters);
                        _bmiResult.Text = $"Your BMI is: {bmi:F2}";
                    }
                    else
                    {
                        _bmiResult.Text = "Height must be greater than 0";
                    }
                }
                else
                {
                    _bmiResult.Text = "Invalid input. Please enter numbers.";
                }
            }
        }
    }
}
