using UnityEngine;

public class Gear : MonoBehaviour
{
    public ItemData.ItemType type;
    public float rate;

    public void Init(ItemData data)
    {
        // Basic Set
        name = "Gear" + data.itemID;
        transform.parent = GameManager.instance.player.transform;
        transform.localPosition = Vector3.zero;

        // Property Set
        type = data.itemtype;
        rate = data.damages[0];
        ApplyGear();
    }


    public void LevelUP(float rate)
    {
        this.rate = rate;
        ApplyGear();
    }

    void ApplyGear()
    {
        switch (type)
        {
            case ItemData.ItemType.Glove:
                RateUp();
                break;

            case ItemData.ItemType.Shoe:
                SpeedUp();
                break;
        }
    }


    void RateUp()
    {
        Weapon[] weapons = transform.parent.GetComponentsInChildren<Weapon>();

        foreach (Weapon weapon in weapons)
        {
            switch (weapon.id)
            {
                case 0:
                    float speed = 150; // ������ Character.WeaponSpeed �� �����ִµ� ������ ĳ���ͺ� �װ� ��� �ʿ� ������
                    weapon.speed = speed + (speed * rate);
                    break;

                default:
                    speed = 0.5f;
                    weapon.speed = speed * (1f - rate);
                    break;
            }
        }
    }


    void SpeedUp()
    {
        float speed = 5;
        GameManager.instance.player.speed = speed + (speed * rate);
    }
}
