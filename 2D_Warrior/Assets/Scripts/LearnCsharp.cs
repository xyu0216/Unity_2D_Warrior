using UnityEngine;

public class LearnCsharp : MonoBehaviour
{
    public int a = 10, b = 3;

    private void Start()
    {
        print(a > b);
        print(a < b);
        print(a == b);
        print(a != b);

        //並且&&
        print(true && true);
        print(true && false);
        print(false && true);
        print(false && false);

        //或者||
        print(true || true);
        print(true || false);
        print(false || true);
        print(false || false);

        //相反!
        print(!true);
        print(!false);

            }

}
