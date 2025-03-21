﻿#region license
// Copyright 2025 Utah Departement of Transportation
// for IdentityApi - Identity.Business.Accounts/AccountResult.cs
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

namespace Identity.Business.Accounts
{
    public class AccountResult
    {
        public AccountResult(int code, string token, List<string> claims, string? message)
        {
            Claims = claims;
            Token = token;
            Code = code;
            Token = token;
            Message = message;
        }
        public List<string> Claims { get; set; }
        public string Token { get; set; }
        public int Code { get; }
        public string? Message { get; set; }
    }
}