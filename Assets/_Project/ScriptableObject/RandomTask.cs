using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomTask : MonoBehaviour
{
    [SerializeField] private ItemConfigList _itemConfig;

    [SerializeField] private Image _spritePotion;
    [SerializeField] private Image _spritePotionComplete;
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _countPotion;

    [SerializeField] private ListTaskSo _listTaskSo;

    private void Awake()
    {
        RandomPotion();
    }



    private void RandomPotion()
    {
        //var randomPotion = Random.Range(0, itemsPotion.Count);
        //_spritePotion.sprite = itemsPotion[randomPotion].AvatarItem;
        //_description.text = itemsPotion[randomPotion].DescriptionItem;
        //_spritePotionComplete.sprite = itemsPotion[randomPotion].AvatarItem;

        var randomPotionCount = Random.Range(1, 3);
        _countPotion.text = randomPotionCount.ToString();
    }

}
