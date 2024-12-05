using System.Resources;

var text = File.ReadAllText("real.txt");

// xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))
char[] numbers = ['0', '1', '2', '3', '4', '5', '6', '7', '8', '9'];

var state = 0;
string num1 = "";
string num2 = "";
int total = 0;

foreach (var c in text)
{
    switch (state)
    {
        case 0:
            if (c == 'm')
            {
                state = 1;
                continue;
            }
            break;
        case 1:
            if (c == 'u')
            {
                state = 2;
                continue;
            }
            break;
        case 2:
            if (c == 'l')
            {
                state = 3;
                continue;
            }
            break;
        case 3:
            if (c == '(')
            {
                state = 4;
                continue;
            }
            break;
        case 4:
            if (numbers.Contains(c))
            {
                num1 += c;
                continue;
            }
            else if (c == ',' && num1.Length > 0)
            {
                state = 5;
                continue;
            }
            break;
        case 5:
            if (numbers.Contains(c))
            {
                num2 += c;
                continue;
            }
            else if (c == ')' && num2.Length > 0)
            {
                total += int.Parse(num1) * int.Parse(num2);
            }
            break;
    }

    state = 0;
    num1 = "";
    num2 = "";


    // if (state == 0 && c == 'm')
    // {
    //     state++;
    // }
    //
    // if (state == 1 && c == 'u')
    // {
    //     state++;
    // }
    //
    // if (state == 2 && c == 'l')
    // {
    //     state++;
    // }
    //
    // if (state == 3 && c == '(')
    // {
    //     state++;
    // }
    //
    // if (state == 4 && numbers.Contains(c))
    // {
    //     num1 += c;
    // }
    //
    // if (state == 4 && c == ',' && num1.Length > 0)
    // {
    //     state++;
    // }
    //
    // if (state == 5 && numbers.Contains(c))
    // {
    //     num2 += c;
    // }
    //
    // if (state == 5 && c == ')' && num2.Length > 0)
    // {
    //     total += int.Parse(num1) * int.Parse(num2);
    // }
    //
    // state = 0;
    // num1 = "";
}

Console.WriteLine("Total of uncorrupted mul instructions is {0}", total);