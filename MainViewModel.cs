using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MD5Hash;

namespace DigestAuthCalc
{
	class MainViewModel : INotifyPropertyChanged
	{
		public string Username
		{
			get => DigestAuthCalcSettings.Default.Username;
			set
			{
				DigestAuthCalcSettings.Default.Username=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Username)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA1Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA1)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}
		public string Realm
		{
			get => DigestAuthCalcSettings.Default.Realm; set
			{
				DigestAuthCalcSettings.Default.Realm=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Realm)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA1Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA1)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}
		public string Password
		{
			get => DigestAuthCalcSettings.Default.Password;
			set
			{
				DigestAuthCalcSettings.Default.Password=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Password)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA1Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA1)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}
		public string Method
		{
			get => DigestAuthCalcSettings.Default.Method; 
			set
			{
				DigestAuthCalcSettings.Default.Method=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Method)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}
		public string Uri
		{
			get => DigestAuthCalcSettings.Default.Uri;
			set
			{
				DigestAuthCalcSettings.Default.Uri=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Uri)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}
		public string Nonce
		{
			get => DigestAuthCalcSettings.Default.Nonce;
			set
			{
				DigestAuthCalcSettings.Default.Nonce=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Nonce)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}

		public Qop Qop
		{
			get => DigestAuthCalcSettings.Default.Qop;
			set
			{
				DigestAuthCalcSettings.Default.Qop=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Qop)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}

		public string NonceCount
		{
			get => DigestAuthCalcSettings.Default.NonceCount;
			set
			{
				DigestAuthCalcSettings.Default.NonceCount=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NonceCount)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}

		public string ClientNonce
		{
			get => DigestAuthCalcSettings.Default.ClientNonce;
			set
			{
				DigestAuthCalcSettings.Default.ClientNonce=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ClientNonce)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}

		public string EntityBody
		{
			get => DigestAuthCalcSettings.Default.EntityBody;
			set
			{
				DigestAuthCalcSettings.Default.EntityBody=value;
				DigestAuthCalcSettings.Default.Save();
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(EntityBody)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2Source)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA2)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HASource)));
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(HA)));
			}
		}

		public string HA1Source => $"{Username}:{Realm}:{Password}";
		public string HA2Source => Qop == Qop.AuthInt ? $"{Method}:{Uri}:{Hash.Content(EntityBody)}" : $"{Method}:{Uri}";
		public string HA1 => Hash.Content(HA1Source);
		public string HA2 => Hash.Content(HA2Source);
		public string HASource => Qop == Qop.None ? $"{HA1}:{Nonce}:{HA2}" :  $"{HA1}:{Nonce}:{NonceCount}:{ClientNonce}:{Qop.GetAttributeOfType<DisplayAttribute>().Name}:{HA2}";
		public string HA => Hash.Content(HASource);

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
