using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using Xunit;

namespace Microsoft.Maui.Essentials.DeviceTests
{
	public class Geocoding_Tests
	{
		public Geocoding_Tests()
		{
#if WINDOWS_UWP || WINDOWS
			ApplicationModel.Platform.MapServiceToken = "RJHqIE53Onrqons5CNOx~FrDr3XhjDTyEXEjng-CRoA~Aj69MhNManYUKxo6QcwZ0wmXBtyva0zwuHB04rFYAPf7qqGJ5cHb03RCDw1jIW8l";
#endif
		}

		[Theory]
		[InlineData(47.673988, -122.121513)]
		public async Task Get_Placemarks_LatLong(double latitude, double longitude)
		{
			try
			{
				var placemarks = await Geocoding.GetPlacemarksAsync(latitude, longitude);

				Assert.NotNull(placemarks);
				Assert.True(placemarks.Any());
			}
			catch (Exception ex) when (IsEmulatorFailure(ex))
			{
			}
		}

		[Theory]
		[InlineData(47.673988, -122.121513)]
		public async Task Get_Placemarks_Location(double latitude, double longitude)
		{
			try
			{
				var placemarks = await Geocoding.GetPlacemarksAsync(new Location(latitude, longitude));

				Assert.NotNull(placemarks);
				Assert.True(placemarks.Any());
			}
			catch (Exception ex) when (IsEmulatorFailure(ex))
			{
			}
		}

		[Theory]
		[InlineData("Redmond, WA, USA")]
		public async Task Get_Locations(string address)
		{
			try
			{
				var locations = await Geocoding.GetLocationsAsync(address);

				Assert.NotNull(locations);
				Assert.True(locations.Any());
			}
			catch (Exception ex) when (IsEmulatorFailure(ex))
			{
			}
		}

		static bool IsEmulatorFailure(Exception ex) =>
			ex.Message.Contains("grpc", StringComparison.OrdinalIgnoreCase) || ex.Message.Contains("service not available", StringComparison.OrdinalIgnoreCase);
	}
}
