//
//  MPSPaymentTransaction.h
//  MOBPaySDK
//
//  Created by youzu_Max on 2017/11/30.
//  Copyright © 2017年 youzu. All rights reserved.
//

#import <MOBFoundation/MOBFDataModel.h>

@interface MPSPaymentTransaction : MOBFDataModel

/**
 支付渠道
 */
@property (nonatomic, assign) MPSChannel channel;

/**
 支付id,用于支付结果查询
 */
@property (nonatomic, copy) NSString *ticketId;

/**
 错误信息
 */
@property (nonatomic, strong) NSError *error;

@end
