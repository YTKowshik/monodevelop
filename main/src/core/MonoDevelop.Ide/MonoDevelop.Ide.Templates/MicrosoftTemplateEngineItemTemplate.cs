﻿//
// MicrosoftTemplateEngineItemTemplate.cs
//
// Author:
//       Matt Ward <matt.ward@xamarin.com>
//
// Copyright (c) 2017 Xamarin Inc. (http://xamarin.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using Microsoft.TemplateEngine.Abstractions;
using MonoDevelop.Ide.Codons;

namespace MonoDevelop.Ide.Templates
{
	class MicrosoftTemplateEngineItemTemplate : ItemTemplate
	{
		public MicrosoftTemplateEngineItemTemplate (ItemTemplateExtensionNode template, ITemplateInfo templateInfo)
			: base (template.TemplateId, template.OverrideName ?? templateInfo.Name)
		{
			TemplateInfo = templateInfo;

			Language = GetLanguage (templateInfo);

			SupportedParameters = MicrosoftTemplateEngine.MergeSupportedParameters (template.SupportedParameters, templateInfo);
			DefaultParameters = MicrosoftTemplateEngine.MergeDefaultParameters (template.DefaultParameters, templateInfo);
		}

		internal ITemplateInfo TemplateInfo { get; private set; }

		static string GetLanguage (ITemplateInfo templateInfo)
		{
			ICacheTag languageTag;
			if (templateInfo.Tags.TryGetValue ("language", out languageTag)) {
				return languageTag.DefaultValue;
			}

			return string.Empty;
		}
	}
}
