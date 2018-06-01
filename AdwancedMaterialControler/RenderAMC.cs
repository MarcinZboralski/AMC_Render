using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AdwancedMaterialControler
{
    [RequireComponent(typeof(Renderer))]
    public sealed class RenderAMC : MonoBehaviour
    {
	    private CoreAMC coreAmc;

	    private int nameBaseCount;

        private new Renderer renderer;

	    private string nameBase;

	    private int value;

	    private bool useCustomShader;

	    private bool useCustomTexture;

	    private Shader customShader;

	    private Texture customTexture;

	    private int silderNameBase;



	    public CoreAMC CoreAmc
	    {
		    get { return coreAmc; }
	    }

	    public int NameBaseCount
	    {
		    get { return nameBaseCount; }
	    }

	    public Renderer Renderer
	    {
		    get { return renderer; }
	    }

	    public string NameBase
	    {
		    get { return nameBase; }
	    }

	    public int Value
	    {
		    get { return value; }
		    set { this.value = value; }
	    }

	    public bool UseCustomShader
	    {
		    get { return useCustomShader; }
		    set { useCustomShader = value; }
		}

	    public bool UseCustomTexture
	    {
		    get { return useCustomTexture; }
		    set { useCustomTexture = value; }
	    }

		public Shader CustomShader
	    {
		    get { return customShader; }
		    set { CustomShader = value; }
		}

	    public Texture CustomTexture
	    {
		    get { return customTexture; }
		    set { CustomTexture = value; }
		}

	    public int SliderNameBase
	    {
		    get { return silderNameBase; }
		    set { silderNameBase = value; }
	    }



	    void Awake()
        {
            UpdateComponets();
        }

        void OnEnable()
        {
            DontDestroyOnLoad(this);
        }

        public void UpdateComponets()
        {
            coreAmc = CoreAMC.istance;
            renderer = GetComponent<Renderer>();
            nameBaseCount = coreAmc.GetNameDataCount(nameBase);
            UpdateRender(0);
        }

        public void UpdateRender(int value)
        {
            nameBaseCount = coreAmc.GetNameDataCount(nameBase);
            nameBase = coreAmc.amcData[silderNameBase].DataName;

            if (useCustomTexture == false)
            {
                renderer.material.mainTexture = coreAmc.GetTexture(nameBase, value);
            }
            else
            {
                if (customTexture == null)
                {
                    renderer.material.mainTexture = coreAmc.GetTexture(nameBase, value);
                    useCustomTexture = false;
                }
                else
                {
                    renderer.material.mainTexture = customTexture;
                }
            }

            if (useCustomShader == false)
            {
                renderer.material.shader = coreAmc.GetShader(nameBase);
            }
            else
            {
                if (CustomShader == null)
                {
                    renderer.material.shader = coreAmc.GetShader(nameBase);
                    useCustomShader = false;
                }
                else
                {
                    renderer.material.shader = CustomShader;
                }
            }
           
        }

        public void RemoveThisComponent()
        {
            DestroyImmediate(this);
        }
    }
}

