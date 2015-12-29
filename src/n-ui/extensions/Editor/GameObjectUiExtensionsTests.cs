#if N_UI_TESTS
using UnityEngine;
using UnityEngine.UI;
using NUnit.Framework;
using N;
using N.Package.UI;

public class GameObjectUiExtensionsTests : N.Tests.Test
{
    [Test]
    public void test_set_slider_value()
    {
        var obj = this.SpawnComponent<Slider>();
        Assert(obj.gameObject.SetSlider(1.0f));
        this.TearDown();
    }

    [Test]
    public void test_set_text_value()
    {
        var obj = this.SpawnComponent<UnityEngine.UI.Text>();
        Assert(obj.gameObject.SetText("Hello World"));
        this.TearDown();
    }
}
#endif
