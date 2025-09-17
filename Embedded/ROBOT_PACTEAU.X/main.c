#include <stdio.h>
#include <stdlib.h>
#include <xc.h>
#include "ChipConfig.h"
#include "IO.h"
#include "timer.h"
#include "pwm.h"
#include "robot.h"
#include "adc.h"

int main (void){
    /***********************************************************************************************/
    //Initialisation oscillateur
    /***********************************************************************************************/
    InitOscillator();

    /***********************************************************************************************/
    // Configuration des input et output (IO)
    /***********************************************************************************************/
    InitIO();
    LED_BLANCHE_1 = 1;
    LED_BLEUE_1 = 1;
    LED_ORANGE_1 = 1;
    LED_ROUGE_1 = 1;
    LED_VERTE_1 = 1;
    
    LED_BLANCHE_2 = 1;
    LED_BLEUE_2 = 1;
    LED_ORANGE_2 = 1;
    LED_ROUGE_2 = 1;
    LED_VERTE_2 = 1;
   
    
    InitADC1();
    //InitTimer23();
    InitTimer1();
    
    unsigned int ADCValue0, ADCValue1, ADCValue2;
    unsigned int * result = ADCGetResult();
    //InitPWM();
    //PWMSetSpeedConsigne(20,MOTEUR_DROIT);
    //PWMSetSpeedConsigne(-20,MOTEUR_GAUCHE);
    /***********************************************************************************************/
    // Boucle Principale
    /***********************************************************************************************/
    while(1)
    {
        if (ADCIsConversionFinished() == 1) {
            ADCClearConversionFinishedFlag();
            ADCValue0 = result[0]; 
            ADCValue1 = result[1]; 
            ADCValue2 = result[2]; 
        }
    } // fin main
}