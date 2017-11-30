// CLIMonteCarloEuropeanCall.h

#pragma once
#include "MCEC.h"

using namespace System;

namespace CLIMonteCarloEuropeanCall {
	public ref struct MTECOptions
	{
	public:
		int Steps; //500
		int Simulations; //10000
		double Maturity; //1
		double Strike; // 100
		double Spot; //100
		double Volatility; //0.30
		double InterestRate; //0.05

	};

	public ref class CLIMCECall
	{
		public : 
			double SimulateMTEC(MTECOptions^ mtecOptions);
	};
}
