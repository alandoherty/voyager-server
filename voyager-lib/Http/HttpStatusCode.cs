using System;

namespace voyagerlib.http
{
	public enum HttpStatusCode : short
	{
		Continue = 100,
		OK = 200,
		Created = 201,
		Accepted = 202,
		MovedPermanently = 301,
		Found = 302,
		TemporaryRedirect = 307,
		PermanentRedirect = 308,
		BadRequest = 400,
		Unauthorized = 401,
		PaymentRequired = 402,
		Forbidden = 403,
		NotFound = 404
	}
}

