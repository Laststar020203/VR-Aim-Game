public class EnemyAttack<T>
{
    private float[] value;
    private T name;

    public float[] Value
    {
        get { return value; }
    }
    public T Name
    {
        get { return name; }
    }

    public EnemyAttack(T name, float[] value)
    {
        this.name = name;
        this.value = value;
    }
}
