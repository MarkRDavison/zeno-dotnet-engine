namespace mark.davison_engine.game.tests.Services;

[TestClass]
public class InputActionManagerTests
{
    private readonly Mock<IInputManager> inputManager;
    private readonly InputActionManager inputActionManager;

    public InputActionManagerTests()
    {
        inputManager = new(MockBehavior.Strict);
        inputActionManager = new(inputManager.Object);
    }

    [TestMethod]
    public void IsActionInvoked_ForNonRegistered_ReturnsFalse()
    {
        inputActionManager
            .IsActionInvoked("CLICK")
            .Should().BeFalse();
    }

    [TestMethod]
    public void InputManager_HandlesKeyInteractions_ForRegisteredAction()
    {
        InputAction action = new()
        {
            Primary = InputActivationType.KeyPress,
            PrimaryKey = KeyboardKey.KEY_A
        };

        inputManager
            .Setup(_ => _.IsKeyPressed(KeyboardKey.KEY_A))
            .Returns(true)
            .Verifiable();

        inputManager
            .Setup(_ => _.IsKeyDown(KeyboardKey.KEY_A))
            .Returns(true)
            .Verifiable();

        inputActionManager.RegisterAction("PRESS", action);

        inputActionManager
            .IsActionInvoked("PRESS")
            .Should().BeTrue();

        inputManager
            .Verify(
                _ => _.IsKeyPressed(KeyboardKey.KEY_A),
                Times.Once);

        inputManager
            .Verify(
                _ => _.IsKeyDown(KeyboardKey.KEY_A),
                Times.Once);
    }

    [TestMethod]
    public void InputManager_HandlesButtonInteractions_ForRegisteredAction()
    {
        InputAction action = new()
        {
            Primary = InputActivationType.MouseButtonPress,
            PrimaryButton = MouseButton.MOUSE_BUTTON_LEFT
        };

        inputManager
            .Setup(_ => _.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT))
            .Returns(true)
            .Verifiable();

        inputManager
            .Setup(_ => _.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            .Returns(true)
            .Verifiable();

        inputActionManager.RegisterAction("CLICK", action);

        inputActionManager
            .IsActionInvoked("CLICK")
            .Should().BeTrue();

        inputManager
            .Verify(
                _ => _.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT),
                Times.Once);

        inputManager
            .Verify(
                _ => _.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT),
                Times.Once);
    }

    [TestMethod]
    public void InputManager_HandlesSecondaryKeyInteractions_ForRegisteredAction()
    {
        InputAction action = new()
        {
            Primary = InputActivationType.KeyPress,
            PrimaryKey = KeyboardKey.KEY_B,
            Secondary = InputActivationType.KeyPress,
            SecondaryKey = KeyboardKey.KEY_A
        };

        inputManager
            .Setup(_ => _.IsKeyPressed(It.IsAny<KeyboardKey>()))
            .Returns((KeyboardKey k) => k == KeyboardKey.KEY_A)
            .Verifiable();

        inputManager
            .Setup(_ => _.IsKeyDown(It.IsAny<KeyboardKey>()))
            .Returns((KeyboardKey k) => k == KeyboardKey.KEY_A)
            .Verifiable();

        inputActionManager.RegisterAction("PRESS", action);

        inputActionManager
            .IsActionInvoked("PRESS")
            .Should().BeTrue();

        inputManager
            .Verify(
                _ => _.IsKeyPressed(It.IsAny<KeyboardKey>()),
                Times.AtLeastOnce);

        inputManager
        .Verify(
                _ => _.IsKeyDown(It.IsAny<KeyboardKey>()),
                Times.AtLeastOnce);
    }

    [TestMethod]
    public void InputManager_HandlesSecondaryButtonInteractions_ForRegisteredAction()
    {
        InputAction action = new()
        {
            Primary = InputActivationType.MouseButtonPress,
            PrimaryButton = MouseButton.MOUSE_BUTTON_RIGHT,
            Secondary = InputActivationType.MouseButtonPress,
            SecondaryButton = MouseButton.MOUSE_BUTTON_LEFT
        };

        inputManager
            .Setup(_ => _.IsMouseButtonPressed(It.IsAny<MouseButton>()))
            .Returns((MouseButton b) => b == MouseButton.MOUSE_BUTTON_LEFT)
            .Verifiable();

        inputManager
            .Setup(_ => _.IsMouseButtonDown(It.IsAny<MouseButton>()))
            .Returns((MouseButton b) => b == MouseButton.MOUSE_BUTTON_LEFT)
            .Verifiable();

        inputActionManager.RegisterAction("CLICK", action);

        inputActionManager
            .IsActionInvoked("CLICK")
            .Should().BeTrue();

        inputManager
            .Verify(
                _ => _.IsMouseButtonPressed(It.IsAny<MouseButton>()),
                Times.AtLeastOnce);

        inputManager
        .Verify(
                _ => _.IsMouseButtonDown(It.IsAny<MouseButton>()),
                Times.AtLeastOnce);
    }
}

/*

	TEST_CASE("registered button down action is invoked and delegates to input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		const std::string actionName = "ACTION_NAME";

		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::KeyHold;
		action.primaryKey = ze::Keyboard::Key::Space;

		fakeit::When(Method(inputManager, isKeyDown)).AlwaysReturn(true);

		actionManager.registerAction(actionName, action);

		REQUIRE(actionManager.isActionInvoked(actionName));

		fakeit::Verify(Method(inputManager, isKeyDown).Using(action.primaryKey));
	}

	TEST_CASE("updateCachedInputs invokes the underlying input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		fakeit::When(Method(inputManager, isButtonDown)).AlwaysReturn(true);
		fakeit::When(Method(inputManager, isKeyDown)).AlwaysReturn(true);

		const ze::Keyboard::Key key = ze::Keyboard::Key::Space;
		const ze::Mouse::Button button = ze::Mouse::Button::Left;

		const std::string actionName = "ACTION_NAME";
		InputAction action{};

		action.primaryActivationType = InputAction::InputActivationType::KeyHold;
		action.primaryKey = ze::Keyboard::Key::Space;
		actionManager.registerAction(actionName, action);

		action.primaryActivationType = InputAction::InputActivationType::MouseButtonHold;
		action.primaryButton = ze::Mouse::Button::Left;
		actionManager.registerAction(actionName, action);

		REQUIRE_NOTHROW(actionManager.updateCachedInputs());

		fakeit::Verify(Method(inputManager, isButtonDown).Using(button));
		fakeit::Verify(Method(inputManager, isKeyDown).Using(key));
	}

	TEST_CASE("registered key down action is invoked and delegates to input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		const std::string actionName = "ACTION_NAME";

		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::MouseButtonHold;
		action.primaryButton = ze::Mouse::Button::Left;

		fakeit::When(Method(inputManager, isButtonDown)).AlwaysReturn(true);

		actionManager.registerAction(actionName, action);

		REQUIRE(actionManager.isActionInvoked(action));

		fakeit::Verify(Method(inputManager, isButtonDown).Using(action.primaryButton));
	}

	TEST_CASE("action with no activation type returns false without querying input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		InputAction action{};

		REQUIRE_FALSE(actionManager.isActionInvoked(action));
	}

	TEST_CASE("action with simple key down primary only returns based on underlying input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::KeyHold;
		action.primaryKey = ze::Keyboard::Key::Space;

		fakeit::When(Method(inputManager, isKeyDown)).AlwaysReturn(true);

		REQUIRE(actionManager.isActionInvoked(action));

		fakeit::Verify(Method(inputManager, isKeyDown).Using(action.primaryKey));
	}

	TEST_CASE("action with simple button down primary only returns based on underlying input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::MouseButtonHold;
		action.primaryButton = ze::Mouse::Button::Left;

		fakeit::When(Method(inputManager, isButtonDown)).AlwaysReturn(true);

		REQUIRE(actionManager.isActionInvoked(action));

		fakeit::Verify(Method(inputManager, isButtonDown).Using(action.primaryButton));
	}

	TEST_CASE("action with primary key press using cached inputs works as expected", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		fakeit::When(Method(inputManager, isKeyDown)).AlwaysReturn(true);

		const ze::Keyboard::Key key = ze::Keyboard::Key::Space;

		const std::string actionName = "ACTION_NAME";
		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::KeyPress;
		action.primaryKey = key;

		actionManager.registerAction(actionName, action);

		REQUIRE(actionManager.isActionInvoked(actionName));

		actionManager.updateCachedInputs();

		REQUIRE_FALSE(actionManager.isActionInvoked(actionName));

		fakeit::Verify(Method(inputManager, isKeyDown).Using(key));
	}


	TEST_CASE("action with primary button press using cached inputs works as expected", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		fakeit::When(Method(inputManager, isButtonDown)).AlwaysReturn(true);

		const ze::Mouse::Button button = ze::Mouse::Button::Left;

		const std::string actionName = "ACTION_NAME";
		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::MouseButtonPress;
		action.primaryButton = button;

		actionManager.registerAction(actionName, action);

		REQUIRE(actionManager.isActionInvoked(actionName));

		actionManager.updateCachedInputs();

		REQUIRE_FALSE(actionManager.isActionInvoked(actionName));

		fakeit::Verify(Method(inputManager, isButtonDown).Using(button));
	}

	TEST_CASE("action with primary button press using cached inputs and modifier key works as expected", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		fakeit::When(Method(inputManager, isButtonDown)).AlwaysReturn(true);

		const ze::Mouse::Button button = ze::Mouse::Button::Left;
		fakeit::When(Method(inputManager, isKeyDown)).AlwaysDo([](const ze::Keyboard::Key& _key) -> bool {
			return _key == ze::Keyboard::Key::RControl;
			});

		const std::string actionName = "ACTION_NAME";
		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::MouseButtonPress;
		action.primaryButton = button;
		action.modifierControl = true;

		actionManager.registerAction(actionName, action);

		REQUIRE(actionManager.isActionInvoked(actionName));

		actionManager.updateCachedInputs();

		REQUIRE_FALSE(actionManager.isActionInvoked(actionName));

		fakeit::Verify(Method(inputManager, isButtonDown).Using(button));
	}

	TEST_CASE("action with simple key down secondary only returns based on underlying input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::KeyHold;
		action.primaryKey = ze::Keyboard::Key::Space;
		action.secondaryActivationType = InputAction::InputActivationType::KeyHold;
		action.secondaryKey = ze::Keyboard::Key::BackSpace;

		fakeit::When(Method(inputManager, isKeyDown)).AlwaysDo([&](const ze::Keyboard::Key& _key) -> bool {
			return _key == action.secondaryKey;
			});

		REQUIRE(actionManager.isActionInvoked(action));

		fakeit::Verify(Method(inputManager, isKeyDown).Using(action.primaryKey));
		fakeit::Verify(Method(inputManager, isKeyDown).Using(action.secondaryKey));
	}

	TEST_CASE("action with simple button down secondary only returns based on underlying input manager", "[InputActionManager]") {
		fakeit::Mock<IInputManager> inputManager;
		InputActionManager actionManager(inputManager.get());

		InputAction action{};
		action.primaryActivationType = InputAction::InputActivationType::MouseButtonHold;
		action.primaryButton = ze::Mouse::Button::Left;
		action.secondaryActivationType = InputAction::InputActivationType::MouseButtonHold;
		action.secondaryButton = ze::Mouse::Button::Right;

		fakeit::When(Method(inputManager, isButtonDown)).AlwaysDo([&](const ze::Mouse::Button& _button)->bool {
			return _button == action.secondaryButton;
			});

		REQUIRE(actionManager.isActionInvoked(action));

		fakeit::Verify(Method(inputManager, isButtonDown).Using(action.primaryButton));
		fakeit::Verify(Method(inputManager, isButtonDown).Using(action.secondaryButton));
	}
 */