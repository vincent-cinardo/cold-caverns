using UnityEngine;
using Assets.Scripts.Pathing;
using System.Collections.Generic;
using Assets.Scripts.WorldGeneration;
using Assets.Scripts.Interact.ResourceNodes;

namespace Assets.Scripts.Survival
{
    public class ProvisionManager : MonoBehaviour
    {
        //Might need to add this component before initialize all the characters.
        //Then, check collective hunger every x seconds.

        private List<FuelNode> fuelNodes;
        private List<FoodNode> foodNodes; 
        private List<WaterNode> waterNodes;

        public float collectiveFuel, collectiveWater, collectiveFood;
        public float suppliedFuel;
        public float suppliedWater;
        public float suppliedFood;

        //Time 
        public float eatTime, drinkTime, fuelTime;

        
        // Start is called before the first frame update
        void Start()
        {
            fuelNodes = new List<FuelNode>();
            foodNodes = new List<FoodNode>();
            waterNodes = new List<WaterNode>();
            eatTime = 4.0f;
            drinkTime = 4.0f;
            fuelTime = 4.0f;
            suppliedFuel = 0.0f;
            suppliedWater = 0.0f;
            suppliedFood = 0.0f;
        }

        // Update is called once per frame
        void Update()
        {
            SupplyFuel();
            SupplyWater();
            SupplyFood();
        }

        void SupplyFuel()
        {
            if (fuelTime <= 0)
            {
                if (suppliedFuel < collectiveFuel)
                {
                    //Instantiate a bunch of fuel nodes
                    int randomX = Random.Range(0, LocalMap.mapSizeX);
                    int randomY = Random.Range(0, LocalMap.mapSizeY);
                    if (LocalMap.TileIsEmpty(randomX, randomY))
                    {
                        GameObject fuel = UnityEngine.Resources.Load<GameObject>("Prefabs/Resources/Fuel");
                        Vector3 location = new Vector3(randomX, randomY, -1.0f);
                        fuel = Instantiate(fuel, location, Quaternion.identity);
                        FuelNode node = fuel.GetComponent<FuelNode>();
                        node.mapTile = LocalMap.tiles[randomX, randomY];
                        LocalMap.SetStructure(fuel, randomX, randomY);
                        fuelNodes.Add(node);
                        suppliedFuel += 100.0f;
                    }
                }
                fuelTime = Random.Range(3.0f, 4.0f);
            }
            else
            {
                fuelTime -= Time.deltaTime;
            }
        }

        void SupplyWater()
        {
            if (drinkTime <= 0)
            {
                if (suppliedWater < collectiveWater)
                {
                    //Instantiate a bunch of fuel nodes
                    int randomX = Random.Range(0, LocalMap.mapSizeX);
                    int randomY = Random.Range(0, LocalMap.mapSizeY);
                    if (LocalMap.TileIsEmpty(randomX, randomY))
                    {
                        GameObject water = UnityEngine.Resources.Load<GameObject>("Prefabs/Resources/Water");
                        Vector3 location = new Vector3(randomX, randomY, -1.0f);
                        water = Instantiate(water, location, Quaternion.identity);
                        WaterNode node = water.GetComponent<WaterNode>();
                        node.mapTile = LocalMap.tiles[randomX, randomY];
                        LocalMap.SetStructure(water, randomX, randomY);
                        waterNodes.Add(node);
                        suppliedWater += 100.0f;
                    }
                }
                drinkTime = Random.Range(3.0f, 4.0f);
            }
            else
            {
                drinkTime -= Time.deltaTime;
            }
        }

        void SupplyFood()
        {
            if (eatTime <= 0)
            {
                if (suppliedFood < collectiveFood)
                {
                    //Instantiate a bunch of fuel nodes
                    int randomX = Random.Range(0, LocalMap.mapSizeX);
                    int randomY = Random.Range(0, LocalMap.mapSizeY);
                    if (LocalMap.TileIsEmpty(randomX, randomY))
                    {
                        GameObject food = UnityEngine.Resources.Load<GameObject>("Prefabs/Resources/Food");
                        Vector3 location = new Vector3(randomX, randomY, -1.0f);
                        food = Instantiate(food, location, Quaternion.identity);
                        LocalMap.SetStructure(food, randomX, randomY);
                        FoodNode node = food.GetComponent<FoodNode>();
                        node.mapTile = LocalMap.tiles[randomX, randomY];
                        foodNodes.Add(node);
                        suppliedFood += 100.0f;
                    }
                }
                eatTime = Random.Range(3.0f, 4.0f);
            }
            else
            {
                eatTime -= Time.deltaTime;
            }
        }

        public FuelNode ClosestFuel(Vector3 other)
        {
            FuelNode closest = null;
            float closestDistance = 10000.0f;

            //SELECT RANDOM MIGHT BE FASTER
            foreach (FuelNode node in fuelNodes)
            {
                float distance = Vector3.Distance(node.transform.position, other);
                if (closest == null || distance < closestDistance)
                {
                    closest = node;
                    closestDistance = distance;
                }
            }
            return closest;
        }

        public WaterNode ClosestWater(Vector3 other)
        {
            WaterNode closest = null;
            float closestDistance = 10000.0f;

            //SELECT RANDOM MIGHT BE FASTER
            foreach (WaterNode node in waterNodes)
            {
                float distance = Vector3.Distance(node.transform.position, other);
                if (closest == null || distance < closestDistance)
                {
                    closest = node;
                    closestDistance = distance;
                }
            }
            return closest;
        }

        public FoodNode ClosestFood(Vector3 other)
        {
            FoodNode closest = null;
            float closestDistance = 10000.0f;

            //SELECT RANDOM MIGHT BE FASTER
            foreach (FoodNode node in foodNodes)
            {
                float distance = Vector3.Distance(node.transform.position, other);
                if (closest == null || distance < closestDistance)
                {
                    closest = node;
                    closestDistance = distance;
                }
            }
            return closest;
        }
    }
}