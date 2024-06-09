// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Web.Http;

namespace CalculatorApp.DataLoaders
{
	public class CurrencyHttpClient : ICurrencyHttpClient
	{
		// TODO UNO: Windows.Web.Http.HttpClient
		System.Net.Http.HttpClient m_client;
		string m_responseLanguage;
		string m_sourceCurrencyCode;

		static string sc_MetadataUriLocalizeFor = "https://aka.platform.uno/unocalc-static-currencies";
		static string sc_RatiosUriRelativeTo = "https://aka.platform.uno/unocalc-ratios"; // Free API from https://www.exchangerate-api.com/
			// DEBUG STRING "https://uno-assets.platform.uno/calc-currencies/uno-calc/test-currency.json";

		public CurrencyHttpClient()
		{
			m_client = new System.Net.Http.HttpClient()
			{
				DefaultRequestHeaders = {{"origin", "UnoCalculator"}} // Required for Android
			};
			m_responseLanguage = "en-US";
		}

		public void SetSourceCurrencyCode(string sourceCurrencyCode)
		{
			m_sourceCurrencyCode = sourceCurrencyCode;	
		}

		public void SetResponseLanguage(string responseLanguage)
		{
			m_responseLanguage = responseLanguage;
		}

		public async Task<string> GetCurrencyMetadata() => await ExecuteRequestAsync(sc_MetadataUriLocalizeFor); // + m_responseLanguage);

		public async Task<string> GetCurrencyRatios() => await ExecuteRequestAsync(sc_RatiosUriRelativeTo); // + m_sourceCurrencyCode);

		private async Task<string> ExecuteRequestAsync(string url) => await m_client.GetStringAsync(new Uri(url));
	}
}
