﻿#if __IOS__ || MACCATALYST
using PlatformView = Microsoft.Maui.Platform.MauiPicker;
#elif MONOANDROID
using PlatformView = Microsoft.Maui.Platform.MauiPicker;
#elif WINDOWS
using PlatformView = Microsoft.UI.Xaml.Controls.ComboBox;
#elif TIZEN
using PlatformView = Tizen.UIExtensions.ElmSharp.Entry;
#elif (NETSTANDARD || !PLATFORM) || (NET6_0_OR_GREATER && !IOS && !ANDROID && !TIZEN)
using PlatformView = System.Object;
#endif

namespace Microsoft.Maui.Handlers
{
	public partial class PickerHandler : IPickerHandler
	{
		public static IPropertyMapper<IPicker, IPickerHandler> Mapper = new PropertyMapper<IPicker, PickerHandler>(ViewMapper)
		{
#if __ANDROID__ || WINDOWS
			[nameof(IPicker.Background)] = MapBackground,
#endif
			[nameof(IPicker.CharacterSpacing)] = MapCharacterSpacing,
			[nameof(IPicker.Font)] = MapFont,
			[nameof(IPicker.SelectedIndex)] = MapSelectedIndex,
			[nameof(IPicker.TextColor)] = MapTextColor,
			[nameof(IPicker.Title)] = MapTitle,
			[nameof(IPicker.TitleColor)] = MapTitleColor,
			[nameof(ITextAlignment.HorizontalTextAlignment)] = MapHorizontalTextAlignment,
			[nameof(ITextAlignment.VerticalTextAlignment)] = MapVerticalTextAlignment
		};

		public static CommandMapper<IPicker, IPickerHandler> CommandMapper = new(ViewCommandMapper)
		{
			["Reload"] = MapReload
		};

		static PickerHandler()
		{
#if __IOS__
			Mapper.PrependToMapping(nameof(IView.FlowDirection), (h, __) => h.UpdateValue(nameof(ITextAlignment.HorizontalTextAlignment)));
#endif
		}

		public PickerHandler() : base(Mapper, CommandMapper)
		{
		}

		public PickerHandler(IPropertyMapper mapper) : base(mapper)
		{
		}

		IPicker IPickerHandler.VirtualView => VirtualView;

		PlatformView IPickerHandler.PlatformView => PlatformView;
	}
}
