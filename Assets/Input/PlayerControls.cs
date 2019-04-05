// GENERATED AUTOMATICALLY FROM 'Assets/Input/PlayerControls.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class PlayerControls : InputActionAssetReference
{
    public PlayerControls()
    {
    }
    public PlayerControls(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Cube
        m_Cube = asset.GetActionMap("Cube");
        m_Cube_Move = m_Cube.GetAction("Move");
        m_Cube_Reset = m_Cube.GetAction("Reset");
        m_Cube_LoadSecretLevel = m_Cube.GetAction("LoadSecretLevel");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Cube = null;
        m_Cube_Move = null;
        m_Cube_Reset = null;
        m_Cube_LoadSecretLevel = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Cube
    private InputActionMap m_Cube;
    private InputAction m_Cube_Move;
    private InputAction m_Cube_Reset;
    private InputAction m_Cube_LoadSecretLevel;
    public struct CubeActions
    {
        private PlayerControls m_Wrapper;
        public CubeActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move { get { return m_Wrapper.m_Cube_Move; } }
        public InputAction @Reset { get { return m_Wrapper.m_Cube_Reset; } }
        public InputAction @LoadSecretLevel { get { return m_Wrapper.m_Cube_LoadSecretLevel; } }
        public InputActionMap Get() { return m_Wrapper.m_Cube; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(CubeActions set) { return set.Get(); }
    }
    public CubeActions @Cube
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new CubeActions(this);
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get

        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
}
