namespace mark.davison.engine.examples.common.Scenes;

[SceneRegistration(Name = Scenes.ThreeDee)]
public class ThreeDeeScene : IScene
{
    private readonly ISceneTransitionService _sceneTransitionService;
    private readonly IImmediateModeRenderer _immediateModeRenderer;
    private readonly ISoundManager _soundManager;
    private readonly IModelManager _modelManager;

    public ThreeDeeScene(
        ISceneTransitionService sceneTransitionService,
        IImmediateModeRenderer immediateModeRenderer,
        ISoundManager soundManager,
        IModelManager modelManager)
    {
        _sceneTransitionService = sceneTransitionService;
        _immediateModeRenderer = immediateModeRenderer;
        _soundManager = soundManager;
        _modelManager = modelManager;
    }

    public void Init()
    {

    }

    public void Render()
    {
        _immediateModeRenderer.Begin3D();
        _immediateModeRenderer.RenderModel(_modelManager.GetModel("satelliteDish_large"), Vector3.Zero);
        _immediateModeRenderer.End3D();
    }

    public void Update(float delta)
    {

    }
}
