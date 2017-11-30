#include "stdafx.h"
#include "MCEC.h"
#include <cmath>
#include <algorithm>
#include <conio.h>
#include <vector>

MCEC::MCEC()
{
}


MCEC::~MCEC()
{
}


double MCEC::SimulateMTEC(MTEuropeanCall mtecOptions)
{

	double sumpayoff = 0;
	double premium = 0;
	double dt = mtecOptions.Maturity / mtecOptions.Steps;
	//double *S = new double[mtecOptions.Steps + 1];
	std::vector<double> S(mtecOptions.Steps + 1);
	
	// STEP 2: MAIN SIMULATION LOOP
	for (int j = 0; j < mtecOptions.Simulations; j++)
	{

		S[0] = mtecOptions.Spot; // initialize each path for simulation

				   // STEP 3 : TIME INTEGRATION LOOP
		for (int i = 0; i < mtecOptions.Steps; i++) 
		{
			double epsilon = SampleBoxMuller(); //get Gaussian draw
			S[i + 1] = S[i] * (1 + mtecOptions.InterestRate *dt + mtecOptions.Volatility *sqrt(dt)*epsilon);
		}

		// STEP 4 : COMPUTE PAYOFF
		sumpayoff += std::max(S[mtecOptions.Steps] - mtecOptions.Strike, 0.0); // compute and payoff		
	}

	// STEP 5: COMPUTE DISCOUNTED EXPECTED PAYOFF
	premium = exp(-mtecOptions.InterestRate*mtecOptions.Maturity)*(sumpayoff / mtecOptions.Simulations);
	return premium;
}

double MCEC::SampleBoxMuller()
{
	double result;
	double x;
	double y;

	double xysquare;

	do {
		x = 2.0*rand() / static_cast<double>(RAND_MAX) - 1;
		y = 2.0*rand() / static_cast<double>(RAND_MAX) - 1;
		xysquare = x*x + y*y;
	} while (xysquare >= 1.0);

	result = x*sqrt(-2 * log(xysquare) / xysquare);

	return result;

}