//
//  PaySDK_Unity3DBridge.m
//  MobPaySDKDemo
//
//  Created by Max on 2018/2/1.
//  Copyright © 2018年 youzu. All rights reserved.
//

#import <MOBPaySDK/MOBPay.h>
#import <MOBFoundation/MOBFoundation.h>

@interface PaySDKUnityPluginObserver: NSObject <MOBPayObserverDelegate>
+ (instancetype)globalObserver;
@property (nonatomic, copy) NSString *observer;
@end

@implementation PaySDKUnityPluginObserver
+ (instancetype)globalObserver
{
    static PaySDKUnityPluginObserver *shared = nil;
    static dispatch_once_t instanceToken;
    dispatch_once(&instanceToken, ^{
        shared = [[PaySDKUnityPluginObserver alloc] init];
        [MOBPay addObserver:shared];
    });
    return shared;
}

- (void)paymentTransaction:(MPSPaymentTransaction *)transaction statusDidChange:(MPSPayStatus)status
{
    NSDictionary *result = @{
                             @"status":@(status),
                             @"ticketId":transaction.ticketId?:@"",
                             @"errorCode":@(transaction.error.code),
                             @"errorDes":transaction.error.description?:@""};
    
    const char *resultCsr = [MOBFJson jsonStringFromObject:result].UTF8String;
    
    UnitySendMessage(self.observer.UTF8String, "_iOSPaysdkCallBack", resultCsr);
}

@end


#if defined (__cplusplus)
extern "C" {
#endif

    void __iosPaySDKPayWithOrder(void *order, int channel, void *observer)
    {
        NSString *orderJson = nil;
        NSString *observerStr = nil;
        
        if (order != NULL)
        {
            orderJson = [NSString stringWithCString:order encoding:NSUTF8StringEncoding];
        }
        
        if (observer !=NULL)
        {
            observerStr = [NSString stringWithCString:observer encoding:NSUTF8StringEncoding];
            [PaySDKUnityPluginObserver globalObserver].observer = observerStr;
        }
        
        NSDictionary *dic = [MOBFJson objectFromJSONString:orderJson];
        MPSCharge *charge = [[MPSCharge alloc] initWithDict:dic];
        charge.channel = channel;
        [MOBPay payWithCharge:charge];
    }
    
    void __iosPaySDKPayWithTicketId(void *ticketId, void *observer)
    {
        NSString *ticketIdStr = nil;
        NSString *observerStr = nil;
        
        if (observer !=NULL)
        {
            observerStr = [NSString stringWithCString:observer encoding:NSUTF8StringEncoding];
            [PaySDKUnityPluginObserver globalObserver].observer = observerStr;
        }
        
        if (ticketId != NULL)
        {
            ticketIdStr = [NSString stringWithCString:ticketId encoding:NSUTF8StringEncoding];
        }
        [MOBPay payWithTicketId:ticketIdStr];
    }
    
    void * __iosPaySDKGetVersion()
    {
        NSString *version = [MOBPay version];
        return (void *)version.UTF8String;
    }
    
    void __iosPaySDKSetDebugMode(BOOL enable)
    {
        [MOBPay setDebugMode:enable];
    }
    
#if defined (__cplusplus)
}
#endif

