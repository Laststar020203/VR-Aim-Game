public interface Entity
{
    string NAME { get; set; }
    int HP { get; set; }
    float FIRE_COOL_TIME { get; set; }

    void Death();
}
