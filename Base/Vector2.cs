using System;

public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public Vector2(float value)
    {
        this.x = value;
        this.y = value;
    }

    /*public static bool operator ==(Vector2 a, Vector2 b)
    {
        return a.x == b.x && a.y == b.y;
    }

    public static bool operator !=(Vector2 a, Vector2 b)
    {
        return !(a == b);
    }*/

    public static Vector2 Zero => new Vector2(0, 0);

    public static Vector2 Distance(Vector2 a, Vector2 b)
    {
        var newX = a.x - b.x;
        var newY = a.y - b.y;

        newX = Math.Abs(newX);
        newY = Math.Abs(newY);
        return new Vector2(newX, newY);
    }
    public static Vector2 Sumar2Vetores(Vector2 a, Vector2 b)
    {
        var newX = a.x + b.x;
        var newY = a.y + b.y;

        return new Vector2(newX, newY);
    }

    public static Vector2 Restar2Vetores(Vector2 a, Vector2 b)
    {
        var newX = a.x - b.x;
        var newY = a.y - b.y;

        return new Vector2(newX, newY);
    }

    public static Vector2 VectorPorEscalar(Vector2 a, float b)
    {
        var newX = a.x * b;
        var newY = a.y * b;

        return new Vector2(newX, newY);
    }

    public static Vector2 VectorDivididoEscalar(Vector2 a, float b)
    {
        var newX = a.x / b;
        var newY = a.y / b;

        return new Vector2(newX, newY);
    }

     public static float Magnitud(Vector2 a)
     {
         float magnitud = (float) Math.Sqrt(a.x * a.x + a.y * a.y);
         return magnitud;
     }

     public static Vector2 VectorNormalizado(Vector2 a)
     {
         var magnitud = Magnitud(a);
         var newX = a.x / magnitud;
         var newY = a.y / magnitud;

         return new Vector2(newX, newY);
     }

     public static float Escalar(Vector2 a, Vector2 b)
     {
         float escalar = a.x * b.x + a.y * b.y;
         return escalar;
     }
}