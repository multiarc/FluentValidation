#region License
// Copyright (c) Jeremy Skinner (http://www.jeremyskinner.co.uk)
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
// http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
// 
// The latest version of this file can be found at http://www.codeplex.com/FluentValidation
#endregion

namespace FluentValidation.Results {
	using System;
	using System.Collections.Generic;

#if !SILVERLIGHT && !PORTABLE && !PORTABLE40 && !DNXCORE50
	[Serializable]
#endif
	public class ValidationFailure {
		private ValidationFailure() {
			
		}

		/// <summary>
		/// Creates a new validation failure.
		/// </summary>
		public ValidationFailure(string propertyName, string error) : this(propertyName, error, null) {
		}

		/// <summary>
		/// Creates a new ValidationFailure.
		/// </summary>
		public ValidationFailure(string propertyName, string error, object attemptedValue) {
			PropertyName = propertyName;
			ErrorMessage = error;
			AttemptedValue = attemptedValue;
		}

		/// <summary>
		/// The name of the property.
		/// </summary>
		public string PropertyName { get; private set; }
		
		/// <summary>
		/// The error message
		/// </summary>
		public string ErrorMessage { get; private set; }
		
		/// <summary>
		/// The property value that caused the failure.
		/// </summary>
		public object AttemptedValue { get; private set; }
		
		/// <summary>
		/// Custom state associated with the failure.
		/// </summary>
		public object CustomState { get; set; }
		
		/// <summary>
		/// Gets or sets the error code.
		/// </summary>
		public string ErrorCode { get; set; }

		/// <summary>
		/// Gets or sets the formatted message arguments.
		/// These are values for custom formatted message in validator resource files
		/// Same formatted message can be reused in UI and with same number of format placeholders
		/// Like "Value {0} that you entered should be {1}"
		/// </summary>
		public object[] FormattedMessageArguments { get; set; }

		/// <summary>
		/// Gets or sets the formatted message placeholder values.
		/// Similar placeholders are defined in fluent validation library (check documentation)
		/// </summary>
		public Dictionary<string, object> FormattedMessagePlaceholderValues { get; set; }
		
		/// <summary>
		/// Creates a textual representation of the failure.
		/// </summary>
		public override string ToString() {
			return ErrorMessage;
		}
	}
}