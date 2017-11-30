#pragma once
struct MTEuropeanCall
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

class MCEC
{
public:
	MCEC();
	~MCEC();
public:
	 double  SimulateMTEC(MTEuropeanCall mtecOptions);

private:
	double SampleBoxMuller();

};

