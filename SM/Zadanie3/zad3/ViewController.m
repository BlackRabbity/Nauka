//
//  ViewController.m
//  zad3
//
//  Created by student on 18/10/2021.
//  Copyright © 2021 wvffle.net. All rights reserved.
//

#import "ViewController.h"

@interface ViewController ()

@end

@implementation ViewController

- (void)viewDidLoad {
    [super viewDidLoad];
    [_informationButton setTitle:NSLocalizedString(@"Information", nil) forState:UIControlStateNormal];
    [_image setImage:[UIImage imageNamed:NSLocalizedString(@"image", nil)]];
    // Do any additional setup after loading the view.
}
-(IBAction)enter {
    UIAlertController *alertDialog= [UIAlertController alertControllerWithTitle:NSLocalizedString(@"Information", nil)
                                                        message:[NSString stringWithFormat:NSLocalizedString(@"The faculty is running %i programs on graduate and undergraduate level.",nil),4] preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *defaultAction=[UIAlertAction actionWithTitle:@"OK"
    style:UIAlertActionStyleDefault
    handler:^(UIAlertAction *action){}];
    
    [alertDialog addAction:defaultAction];
    
    [self presentViewController:alertDialog animated:YES completion:nil];}

@end
