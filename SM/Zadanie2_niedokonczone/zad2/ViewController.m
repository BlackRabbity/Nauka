//
//  ViewController.m
//  zad2
//
//  Created by student on 18/10/2021.
//  Copyright © 2021 student. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    // Do any additional setup after loading the view, typically from a nib.
}

-(IBAction)enter {
    NSString *yourName = self.inputField.text;
    NSString *myName = @"Michal";
    NSString *message;
    
    if ([yourName length] == 0) {
        yourName = @"World";
    }
    if ([yourName isEqualToString:myName]) {
    message = [NSString stringWithFormat:@"Hello %@! We have the same name :)", yourName];}
    else {
        message = [NSString stringWithFormat:@"Hello %@!", yourName ];
        
    }
    self.messageLabel.text = message;
    
}
-(void) prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender
{
    if ([segue.identifier isEqualToString:@"sendSurnameSegue"])
    {
        SecondViewController *controller = (SecondViewController *) segue.destinationViewController;
        controller.surname = self.surnameTextField.text;
        controller.delegate = self;
    }
}
-(void) addItemViewController:(SecondViewController *)controller didFinishEnteringItem:(NSString *)item{
    NSLog(@"This was returned %@", item);
    self.surnameTextField.text = item;
}
@end
