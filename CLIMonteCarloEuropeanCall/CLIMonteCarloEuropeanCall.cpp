// This is the main DLL file.

#include "stdafx.h"
#include "CLIMonteCarloEuropeanCall.h"
#include <memory>


double CLIMonteCarloEuropeanCall::CLIMCECall::SimulateMTEC(MTECOptions^ mtecOptions)
{
	MCEC mcec;
	//PAS BO
	MTEuropeanCall mtecOpts;
	mtecOpts.Maturity = mtecOptions->Maturity;
	mtecOpts.Strike = mtecOptions->Strike;
	mtecOpts.Spot = mtecOptions->Spot;
	mtecOpts.Volatility = mtecOptions->Volatility;	
	mtecOpts.InterestRate = mtecOptions->InterestRate;
	mtecOpts.Steps = mtecOptions->Steps;
	mtecOpts.Simulations = mtecOptions->Simulations;
	return mcec.SimulateMTEC(mtecOpts);	
}