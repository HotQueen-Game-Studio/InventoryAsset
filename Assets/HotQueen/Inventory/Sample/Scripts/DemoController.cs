using UnityEngine;
using Random = UnityEngine.Random;

namespace HotQueen.Inventory.Sample
{
    public class DemoController : MonoBehaviour
    {
        [SerializeField] private InventoryDemo _inventoryDemo;
        DemoData[] datas = new DemoData[]
        {
            new DemoData("HelloWorld", "Hello world, programmed to work but not to fell... don´t even know if this is real."),
            new DemoData("Gellow", "Gellow is yellow, so hello!!")
        };

        // Update is called once per frame
        void Update()
        {


            //Add random items
            if (Input.GetKeyDown(KeyCode.A))
            {
                AddRandom();
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                //_inventoryDemo.Add(dataB);
            }
        }

        private void AddRandom()
        {
            int random = Random.Range(0, datas.Length);
            _inventoryDemo.Add(datas[random]);
        }
    }
}
