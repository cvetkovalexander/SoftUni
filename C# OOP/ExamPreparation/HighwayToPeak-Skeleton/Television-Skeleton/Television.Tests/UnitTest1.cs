namespace Television.Tests
{
    using System;
    using System.Diagnostics;
    using NUnit.Framework;
    public class Tests
    {
        private const string _defaultBrand = "Samsung";
        private const double _defaultPrice = 3.14;
        private const int _defaultWidth = 100;
        private const int _defaultHeight = 200;
        private TelevisionDevice _testDevice;

        [SetUp]
        public void SetUp()
        {
            this._testDevice = new(_defaultBrand, _defaultPrice, _defaultWidth, _defaultHeight);
        }

        [Test]
        public void InitialStateShouldBeCorrect()
        {
            Assert.That(this._testDevice.Brand, Is.EqualTo(_defaultBrand));
            Assert.That(this._testDevice.Price, Is.EqualTo(_defaultPrice));
            Assert.That(this._testDevice.ScreenWidth, Is.EqualTo(_defaultWidth));
            Assert.That(this._testDevice.ScreenHeigth, Is.EqualTo(_defaultHeight));
        }

        [Test]
        public void SwitchOnShouldWorkCorrectlyIfDeviceIsNotMuted()
        {
            Assert.That(this._testDevice.SwitchOn(),
                Is.EqualTo($"Cahnnel {this._testDevice.CurrentChannel} - Volume {this._testDevice.Volume} - Sound On"));
        }

        [Test]
        public void SwitchOnShouldWorkCorrectlyIfDeviceIsMuted()
        {
            this._testDevice.MuteDevice();
            Assert.That(this._testDevice.SwitchOn(),
                Is.EqualTo($"Cahnnel {this._testDevice.CurrentChannel} - Volume {this._testDevice.Volume} - Sound Off"));
        }

        [TestCase(0), TestCase(1), TestCase(100)]
        public void ChangeChannelShouldWorkCorrectly(int n)
        {
            int channel = n;
            Assert.That(this._testDevice.ChangeChannel(channel), Is.EqualTo(channel));
        }

        [Test]
        public void ChangeChannelShouldThrowAnExceptionIfInvalidChannelValueIsGiven()
        {
            int channel = -1;
            Assert.That(() => this._testDevice.ChangeChannel(channel), Throws.ArgumentException);
        }

        [TestCase(-50), TestCase(0), TestCase(50)]
        public void VolumeChangeShouldWorkCorrectlyIfDirectionIsUp(int n)
        {
            int units = n;
            int lastVolume = this._testDevice.Volume;
            Assert.That(this._testDevice.VolumeChange("UP", units), Is.EqualTo($"Volume: {lastVolume + Math.Abs(units)}"));
        }

        [Test]
        public void VolumeChangeShouldReturn100IfDirectionIsUpAndVolumeExceeds100()
        {
            Assert.That(this._testDevice.VolumeChange("UP", 100), Is.EqualTo($"Volume: 100"));
        }

        [TestCase(-13), TestCase(0), TestCase(5)]
        public void VolumeChangeShouldWorkCorrectlyIfDirectionIsDown(int n)
        {
            int units = n;
            int lastVolume = this._testDevice.Volume;
            Assert.That(this._testDevice.VolumeChange("DOWN", units), Is.EqualTo($"Volume: {lastVolume - Math.Abs(units)}"));
        }

        [Test]
        public void VolumeChangeShouldReturn100IfDirectionIsDownAndVolumeIsLessThanZero()
        {
            Assert.That(this._testDevice.VolumeChange("DOWN", 100), Is.EqualTo($"Volume: 0"));
        }

        [Test]
        public void MuteDeviceShouldWorkCorrectlyIfDeviceIsNotMuted()
        {
            Assert.That(this._testDevice.MuteDevice(), Is.True);
        }

        [Test]
        public void MuteDeviceShouldWorkCorrectlyIfDeviceIsMuted()
        {
            this._testDevice.MuteDevice();
            Assert.That(this._testDevice.MuteDevice(), Is.False);
        }

        [Test]
        public void ToStringShouldWorkCorrectly()
        {
            string expected = $"TV Device: {_defaultBrand}, Screen Resolution: {_defaultWidth}x{_defaultHeight}, Price {_defaultPrice}$";
            Assert.That(this._testDevice.ToString(), Is.EqualTo(expected));
        }
    }
}