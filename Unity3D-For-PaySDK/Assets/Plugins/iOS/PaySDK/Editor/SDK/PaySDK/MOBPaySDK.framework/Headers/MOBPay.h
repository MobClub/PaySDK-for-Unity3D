//
//  MOBPay.h
//  MOBPaySDK
//
//  Created by youzu_Max on 2017/6/28.
//  Copyright © 2017年 youzu. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "MPSCharge.h"
#import "MPSPaymentTransaction.h"

/**
 支付回调协议
 */
@protocol MOBPayObserverDelegate <NSObject>

/**
 支付状态改变回调
 
 @param transaction 本次支付模型
 @param status 支付状态
 */
- (void)paymentTransaction:(MPSPaymentTransaction *)transaction statusDidChange:(MPSPayStatus)status;

@end


@interface MOBPay : NSObject

/**
 设置观察者，监听支付状态改变与回调

 @param observer 回调代理
 */
+ (void)addObserver:(id<MOBPayObserverDelegate>)observer;

/**
 支付接口

 @param charge 支付信息模型
 */
+ (void)payWithCharge:(MPSCharge *)charge;

/**
 使用ticketId进行支付

 @param ticketId 支付标示
 */
+ (void)payWithTicketId:(NSString *)ticketId;

/**
 沙盒模式

 @param enabled 默认关闭
 */
+ (void)setSandBoxMode:(BOOL)enabled;

/**
 版本号

 @return 版本信息
 */
+ (NSString *)version;

/**
 日志打印
 
 @param enabled YES:开启日志 NO:关闭日志
 */
+ (void)setDebugMode:(BOOL)enabled;

@end
