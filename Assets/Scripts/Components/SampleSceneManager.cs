using System.IO;
using UnityEngine;

public class SampleSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject cubeObj;

    [SerializeField]
    private GameObject sphereObj;

    [SerializeField]
    private GameObject cylinderObj;

    private FileController fileController = new FileController();

    void Start()
    {
        string filepath = Application.dataPath + Path.DirectorySeparatorChar + "Datas" + Path.DirectorySeparatorChar + "objectInfos.json";
        string contents = fileController.read(filepath);

        if(!string.IsNullOrEmpty(contents))
        {
            try
            {
                Objects_JSON objJson = JsonUtility.FromJson<Objects_JSON>(contents);

                /* 실행 안 됨
                cubeObj = Resources.Load<GameObject>("Assets/Prefabs/Cube");
                sphereObj = Resources.Load<GameObject>("Assets/Prefabs/Sphere");
                cylinderObj = Resources.Load<GameObject>("Assets/Prefabs/Cylinder");
                */

                for(int i = 0; i < objJson.objects.Count; i++)
                {
                    string type = objJson.objects[i].type;
                    GameObject objToCreate = null;

                    if(type.Equals("cube"))
                    {
                        objToCreate = cubeObj;
                    }
                    else if(type.Equals("sphere"))
                    {
                        objToCreate = sphereObj;
                    }
                    else if(type.Equals("cylinder"))
                    {
                        objToCreate = cylinderObj;
                    }
                
                    if(objToCreate != null)
                    {
                        float x = float.NaN;

                        if(!float.IsNaN(objJson.objects[i].x))
                        {
                            x = objJson.objects[i].x;
                        }

                        float y = float.NaN;

                        if(!float.IsNaN(objJson.objects[i].y))
                        {
                            y = objJson.objects[i].y;
                        }

                        float z = float.NaN;

                        if(!float.IsNaN(objJson.objects[i].z))
                        {
                            z = objJson.objects[i].z;
                        }

                        if(!float.IsNaN(x) && !float.IsNaN(y) && !float.IsNaN(z))
                        {
                            Instantiate(
                                objToCreate,
                                new Vector3(x, y, z),
                                Quaternion.identity
                            );
                        }
                    }
                }
            }
            catch
            {
                Debug.LogError("JSON Parsing Error");
            }
        }
        else
        {
            Debug.LogError("File Read Error");
        }
    }

    void Update()
    {
    }
}
